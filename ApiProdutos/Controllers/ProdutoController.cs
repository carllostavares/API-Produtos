using ApiProduto.Model;
using ApiProdutos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("Api/Produtos")]
    public class ProdutoController : ControllerBase
    {
        public readonly ApiDbContext _context;

        public ProdutoController (ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Produto>>> BuscaProdutos()
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> BuscaPordutoPorId(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> EnviarPordutoPorId(Produto produto)
        {
            if (_context.Produtos == null)
            {
                return Problem("Erro ao tentar criar um produto.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(EnviarPordutoPorId), new {id= produto.Id},produto);

        }


        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> UpdatePordutoPorId(int id,Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest(ModelState); 
            }
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            _context.Produtos.Update(produto);

            await _context.SaveChangesAsync();

            return NoContent();

        }


        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Produto>> DeletaPordutoPorId(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
