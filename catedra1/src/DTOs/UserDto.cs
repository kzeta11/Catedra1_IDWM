using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catedra1.src.DTOs
{
    public class UserDto
    {
        public required string Rut { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public required string Nombre { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico no válido.")]
        public required string Correo { get; set; }

        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo", ErrorMessage = "El género debe ser masculino, femenino, otro o prefriero no decirlo.")]
        public required string Genero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; } 
    }
}