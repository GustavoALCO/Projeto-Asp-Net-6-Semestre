using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto6semestre.Context;
using projeto6semestre.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projeto6semestre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public UsuarioController(OrganizadorContext context)
        {
            _context = context;
        }
        //OrganizadorContext e o ProdutosControler esta servindo para acessar e manipular os dados que estão no banco de dados 

        [HttpGet("BuscarUsuario")]
        public IActionResult Get()
        {
            var usuario = _context.Usuario.ToList();
            if (usuario.Count > 0)
            {
                return Ok(usuario);
            }
            else
                return NotFound();
        }
        //Buscar Todos os Produtos que estão no banco de dados 
        [HttpGet("BuscarUsuarioPorID/{id}")]
        public IActionResult Get(string id)
        {
            var produtos = _context.Usuario.Where(n => n.IdUsuario.ToString() == id).ToList();
            if (produtos == null)
                return NotFound("Não foi possível encontrar produtos com o preço especificado.");

            return Ok(produtos);
        }
        //Busca todos os Produtos que tem o mesmo nome Digitado 

        [HttpGet("BuscarUsuarioPorEmail/{email}")]
        public IActionResult GetProdutoPorNome(string email)
        {
            var produtos = _context.Usuario.Where(n => n.Email == email).ToList();

            if (produtos == null)
            {
                return NotFound("Não foi possível encontrar produtos com o nome especificado.");
            }

            return Ok(produtos);
        }

        [HttpGet("VerificarLogin/{email}/{senha}")]
        public IActionResult Get(string email, string senha)
        {
            var produtos = _context.Usuario.FirstOrDefault(n => n.Email == email && n.Senha == senha);
            if (produtos == null)
                return NotFound("Não foi possível fazer o login");

            return Ok();
        }

        [HttpDelete("DeletarUsuarioPor/{id}")]
        public IActionResult Delete(Guid id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario != null)
            {
                _context.Remove(usuario);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        //Deletando o Usuario pelo Id 

        [HttpPost("CriarUsuario")]
        public IActionResult post(Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Não Foi Possivel Criar");
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut("AlterarUsuario/{Id}")]
        public IActionResult put(string Id, [FromBody] Usuario usuarioNovo)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.IdUsuario.ToString() == Id);

            if (usuario == null) {
                return NotFound("Usuario Não encontrado");
            }

            usuario.Email = usuarioNovo.Email;
            usuario.Senha = usuarioNovo.Senha;
            usuario.Nome = usuarioNovo.Nome;
            usuario.Genero = usuarioNovo.Genero;
            usuario.Endereco = usuarioNovo.Endereco;

            _context.Entry(usuario).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(usuario);
        }
    }
}

