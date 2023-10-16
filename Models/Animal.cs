using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petshop.Models
{
    [Table("Animais")]
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id do Animal")]
        public int idAnimal { get; set; }

        [StringLength(20)]
        [Display(Name = "Nome do Pet")]
        public string nome { get; set; }

        [StringLength(20)]
        [Display(Name = "Gato Ou Cachorro")]
        public string tipoAnimal { get; set; }
    }
}
