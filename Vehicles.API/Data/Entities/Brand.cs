using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vehicles.API.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Marca")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public String Description { get; set; }

        public ICollection<Vehicle> Vehicles { get;set; }
    }
}
