using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petshop.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id do Cliente")]
        public int idCliente { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Esse Campo e OBRIGATORIO!")]
        [Display(Name = "Nome Completo")]
        public string nome { get; set; }
    }
}
