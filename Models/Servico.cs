using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petshop.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Servico")]
        public int id { get; set; }

        [Display(Name = "Animal")]
        public int animalId { get; set; }
        [ForeignKey("idAnimal")]
        public Animal Animal { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId  { get; set; }
        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }

        [Display(Name = "TipoServico")]
        public int TipoServicoId { get; set; }
        [ForeignKey("idTipoServico")]
        public TipoServico TipoServico { get; set; }

        [Display(Name = "Valor Total")]
        [Required(ErrorMessage = "Esse Campo e OBRIGATORIO!")]
        public float valorTotal { get; set; }

        [Display(Name = "Horario do Servico")]
        public string horario { get; set; }

        [Display(Name = "Dia do Servico")]
        public string Data { get; set; }
    }
}
