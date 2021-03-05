using AutoMapper;
using Dotz.Api.Resources.Produto;
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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(
            IProdutoService produtoService,
            IMapper mapper
        )
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProdutoResource>>> GetAll()
        {
            var produtos = await _produtoService.GetAll();
            if (produtos == null)
            {
                return NotFound("Nenhum produto encontrado");
            }

            var produtosResource = _mapper.Map<IEnumerable<ProdutoResource>>(produtos);
            return Ok(produtosResource);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProdutoResource>>> GetById(int id)
        {
            var produto = await _produtoService.GetById(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            var produtoResource = _mapper.Map<ProdutoResource>(produto);
            return Ok(produtoResource);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProdutoResource>> Create([FromBody] CreateProdutoResource createProdutoResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoToCreate = _mapper.Map<Produto>(createProdutoResource);
            var newProduto = await _produtoService.Create(produtoToCreate);
            var produtoResource = _mapper.Map<ProdutoResource>(newProduto);
            return Created(nameof(GetById), produtoResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoResource>> Update(int id, [FromBody] UpdateProdutoResource updateProdutoResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoToUpdate = await _produtoService.GetById(id);
            if (produtoToUpdate == null)
            {
                return NotFound("Produto não encontrado");
            }

            var produto = _mapper.Map<Produto>(updateProdutoResource);
            var newProduto = await _produtoService.Update(produtoToUpdate, produto);
            var newProdutoResource = _mapper.Map<ProdutoResource>(newProduto);
            return Ok(newProdutoResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoResource>> Delete(int id)
        {
            var produtoToDelete = await _produtoService.GetById(id);
            if (produtoToDelete == null)
            {
                return NotFound("Produto não encontrado");
            }

            await _produtoService.Delete(produtoToDelete);
            return NoContent();
        }
    }
}
