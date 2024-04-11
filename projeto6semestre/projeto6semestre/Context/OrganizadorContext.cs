using Microsoft.EntityFrameworkCore;
using projeto6semestre.Models;

namespace projeto6semestre.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }
        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        //para fazer a chamada do banco de dados
    }
}
