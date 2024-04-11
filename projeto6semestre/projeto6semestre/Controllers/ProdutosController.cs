using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto6semestre.Context;
using projeto6semestre.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projeto6semestre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly OrganizadorContext _context;
   
        public ProdutosController(OrganizadorContext context)
        {
            _context = context;
        }
        //OrganizadorContext e o ProdutosControler esta servindo para acessar e manipular os dados que estão no banco de dados 

        [HttpGet("BuscarProdutos")]
        public IActionResult Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos.Count > 0)
            { 
                return Ok(produtos);
            }
            else
                return NotFound();
        }
        //Buscar Todos os Produtos que estão no banco de dados 
        [HttpGet("BuscarProdutosPorID/{id}")]
         public IActionResult Get(string id)
         {
            var produtos = _context.Produtos.Where(n => n.IdProduto.ToString() == id).ToList();
                if (produtos == null)
                    return NotFound("Não foi possível encontrar produtos com o preço especificado.");

                return Ok(produtos);
        }
        //Busca todos os Produtos que tem o mesmo nome Digitado 

        [HttpGet("BuscarProdutosPorNome/{nome}")]
        public IActionResult GetProdutoPorNome(string nome)
        {
            var produtos = _context.Produtos.Where(n => n.Produto == nome).ToList();
    
            if (produtos == null || produtos.Count == 0)
            {
                return NotFound("Não foi possível encontrar produtos com o nome especificado.");
            }

            return Ok(produtos);
        }

        [HttpDelete("DeletarProdutosPor/{id}")]
        public IActionResult Delete(Guid id)
        {
            var produtos = _context.Produtos.Find(id);
            if (produtos != null) 
            {
                _context.Remove(produtos);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();       
        }
        //Deletando o Usuario pelo Id 

        [HttpPost("CriarProdutos")]
        public IActionResult post(Produtos produto)
        {
            if (produto == null)
                return BadRequest("Não Foi Possivel Criar");
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("AlterarProduto/{Id}")]
        public IActionResult put(string Id, [FromBody] Produtos produtoNovo)
        {
            var produto = _context.Produtos.FirstOrDefault(u => u.IdProduto.ToString() == Id);

            if (produto == null)
            {
                return NotFound("produto Não encontrado");
            }
            
            produto.Produto = produtoNovo.Produto;
            produto.Descricao = produtoNovo.Descricao;
            produto.Preco = produtoNovo.Preco;
            

            _context.Entry(produto).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(produto);
        }
    }
}

