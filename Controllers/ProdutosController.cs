using InventoryManager.Data;
using InventoryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        [HttpGet("busca")]
        public ActionResult<IEnumerable<Produto>> GetProdutosByFiltro([FromQuery] string? categoria = null,
        string? tipo = null, [FromQuery] string? marca = null)
        {

            var produtos = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
            {
                produtos = produtos.Where(p => p.Categoria == categoria);
            }

            if (!string.IsNullOrEmpty(tipo))
            {
                produtos = produtos.Where(p => p.Tipo == tipo);
            }

            if (!string.IsNullOrEmpty(marca))
            {
                produtos = produtos.Where(p => p.Marca == marca);
            }

            if (!produtos.Any())
            {
                return NotFound("Nenhum ítem encontrado com os dados fornecidos.");
            }

            return Ok(produtos.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProdutoAsync(Produto produto)
        {

            var produtoExistente = await _context.Produtos
        .FirstOrDefaultAsync(p => p.Modelo == produto.Modelo);

            if (produtoExistente != null)
            {
                return Conflict(new
                {
                    erroCadastro = "Esse ítem já está cadastrado",
                    produto = produtoExistente
                });
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return Conflict (new
                {
                    mensagem = $"ID {id} não corresponde a nenhum ítem no registro",
                    produto
                });

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(new
            {
                mensagem = "Esse ítem foi removido do registro",
                produto
            });
        }
    }
}
