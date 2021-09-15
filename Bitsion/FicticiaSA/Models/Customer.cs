using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FicticiaSA.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "DNI")]
        public string Dni { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Genero")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Maneja")]
        public bool? Drives { get; set; }

        [Display(Name = "Usa anteojos")]
        public bool? NeedsGlasses { get; set; }

    }
}
