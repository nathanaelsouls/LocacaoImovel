using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace APILocacaoImovel.Models
{
    [Table("Locacao")]
    public class LocacaoModel
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("IdImovel")]
        public int IdImovel { get; set; }

        [Column("DataSolicitacao")]
        public string? DataSolicitacao { get; set; }

        [Column("DataInicio")]
        public string? DataInicio { get; set; }

        [Column("DataFim")]
        public string? DataFim { get; set; }
    }
}
