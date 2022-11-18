using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILocacaoImovel.Models
{
    [Table("Imovel")]
    public class ImovelModel
    {
        
        [Column("Id")]
        public int Id { get; set; }

        
        [Column("Nome")]
        public string? Nome { get; set; }

        
        [Column("Descricao")]
        public string? Descricao { get; set; }

        
        [Column("Valor_Locacao")]
        public double ValorLocacao { get; set; }

        [Column("Cep")]
        public string? Cep { get; set; }

        [Column("Endereco")]
        public string? Endereco { get; set; }

        [Column("Bairro")]
        public string? Bairro { get; set; }

        [Column("Cidade")]
        public string? Cidade { get; set; }

        [Column("Estado")]
        public string? Estado { get; set; }

        [Column("Completo1")]
        public string? Completo1 { get; set; }

        [Column("Completo2")]
        public string? Completo2 { get; set; }

    }
}
