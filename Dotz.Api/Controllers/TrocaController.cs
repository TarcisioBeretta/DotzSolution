using AutoMapper;
using Dotz.Api.Resources.Troca;
using Dotz.Core.Models;
using Dotz.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrocasController : ControllerBase
    {
        private readonly ITrocaService _trocaService;
        private readonly IMapper _mapper;

        public TrocasController(
            ITrocaService trocaService,
            IMapper mapper
        )
        {
            _trocaService = trocaService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TrocaResource>>> GetAll()
        {
            var trocas = await _trocaService.GetAll();
            if (trocas == null)
            {
                return NotFound("Nenhum troca encontrado");
            }

            var trocasResource = _mapper.Map<IEnumerable<TrocaResource>>(trocas);
            return Ok(trocasResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TrocaResource>>> GetById(int id)
        {
            var troca = await _trocaService.GetById(id);
            if (troca == null)
            {
                return NotFound("Troca não encontrado");
            }

            var trocaResource = _mapper.Map<TrocaResource>(troca);
            return Ok(trocaResource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TrocaResource>> Create([FromBody] CreateTrocaResource createTrocaResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trocaToCreate = _mapper.Map<Troca>(createTrocaResource);
            trocaToCreate.UsuarioId = GetUserId();

            if (await _trocaService.SaldoInsuficiente(trocaToCreate))
            {
                return BadRequest("Saldo insuficiente");
            }

            var newTroca = await _trocaService.Create(trocaToCreate);
            var newTrocaFromDatabase = await _trocaService.GetById(newTroca.Id);
            var trocaFromDatabaseResource = _mapper.Map<TrocaResource>(newTrocaFromDatabase);
            return Ok(trocaFromDatabaseResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrocaResource>> Update(int id, [FromBody] UpdateTrocaResource updateTrocaResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trocaToUpdate = await _trocaService.GetById(id);
            if (trocaToUpdate == null)
            {
                return NotFound("Troca não encontrado");
            }

            var troca = _mapper.Map<Troca>(updateTrocaResource);
            if(await _trocaService.SaldoInsuficiente(trocaToUpdate, troca))
            {
                return BadRequest("Saldo insuficiente");
            }

            var newTroca = await _trocaService.Update(trocaToUpdate, troca);
            var newTrocaResource = _mapper.Map<TrocaResource>(newTroca);
            return Ok(newTrocaResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrocaResource>> Delete(int id)
        {
            var trocaToDelete = await _trocaService.GetById(id);
            if (trocaToDelete == null)
            {
                return NotFound("Troca não encontrado");
            }

            await _trocaService.Delete(trocaToDelete);
            return NoContent();
        }

        private int GetUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return int.Parse(identity.Name);
        }
    }
}
