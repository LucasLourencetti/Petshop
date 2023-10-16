using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petshop.Models
{
    [Table("TipoServicos")]
    public class TipoServico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id do Tipo do Servico")]
        public int idTipoServico { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Esse Campo e OBRIGATORIO!")]
        [Display(Name = "Descricao do Servico Feito")]
        public string descricao { get; set; }
    }
}
