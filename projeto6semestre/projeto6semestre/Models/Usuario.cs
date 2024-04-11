using System;
using System.ComponentModel.DataAnnotations;

namespace projeto6semestre.Models
{
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Endereco { get; set; }

        public Usuario(string nome, string genero, string email, string senha, string endereco)
        {
            IdUsuario = Guid.NewGuid();
            Nome = nome;
            Genero = genero;
            Email = email;
            Senha = senha;
            Endereco = endereco;
        }
    }
}
