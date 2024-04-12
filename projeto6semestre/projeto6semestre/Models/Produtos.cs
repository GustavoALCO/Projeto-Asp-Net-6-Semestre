using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace projeto6semestre.Models
{
    public class Produtos
    {
        [Key]
        public Guid IdProduto { get; set; }

        public string Imagem { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        

        // Construtor com parâmetros
        public Produtos(string produto, string descricao, double preco, string imagem)
        {
            IdProduto = Guid.NewGuid();
            Produto = produto;
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
        }
    }
}
