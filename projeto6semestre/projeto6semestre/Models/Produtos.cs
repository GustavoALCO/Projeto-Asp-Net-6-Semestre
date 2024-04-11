using System;
using System.ComponentModel.DataAnnotations;

namespace projeto6semestre.Models
{
    public class Produtos
    {
        [Key]
        public Guid IdProduto { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        

        // Construtor com parâmetros
        public Produtos(string produto, string descricao, double preco)
        {
            IdProduto = Guid.NewGuid();
            Produto = produto;
            Descricao = descricao;
            Preco = preco;
        }
    }
}
