using AutoMapper;
using Dotz.Api.Resources.Usuario;
using Dotz.Core.Models;
using Dotz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(
            IUsuarioService usuarioService,
            IMapper mapper
        )
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UsuarioResource>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAll();
            if (usuarios == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }

            var usuariosResource = _mapper.Map<IEnumerable<UsuarioResource>>(usuarios);
            return Ok(usuariosResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UsuarioResource>>> GetById(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var usuarioResource = _mapper.Map<UsuarioResource>(usuario);
            return Ok(usuarioResource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioResource>> Create([FromBody] CreateUsuarioResource createUsuarioResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioToCreate = _mapper.Map<Usuario>(createUsuarioResource);
            var newUsuario = await _usuarioService.Create(usuarioToCreate);
            var usuarioResource = _mapper.Map<UsuarioResource>(newUsuario);
            return Created(nameof(GetById), usuarioResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioResource>> Update(int id, [FromBody] UpdateUsuarioResource updateUsuarioResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioToUpdate = await _usuarioService.GetById(id);
            if (usuarioToUpdate == null)
            {
                return NotFound("Usuario não encontrado");
            }

            var usuario = _mapper.Map<Usuario>(updateUsuarioResource);
            var newUsuario = await _usuarioService.Update(usuarioToUpdate, usuario);
            var newUsuarioResource = _mapper.Map<UsuarioResource>(newUsuario);
            return Ok(newUsuarioResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioResource>> Delete(int id)
        {
            var usuarioToDelete = await _usuarioService.GetById(id);
            if (usuarioToDelete == null)
            {
                return NotFound("Usuario não encontrado");
            }

            await _usuarioService.Delete(usuarioToDelete);
            return NoContent();
        }
    }
}
