using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILocacaoImovel.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string? Nome { get; set;}

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Telefone")]
        public string? Telefone { get; set; }
    }
}
