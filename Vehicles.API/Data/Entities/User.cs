using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data.Entities
{
    public class User : IdentityUser
    {

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public String FirtName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public String LastName { get; set; }

        [Display(Name = "Tipo de Documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public String Document { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Required(ErrorMessage = "El Campo {0} es obligatorio.")]
        public String Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //todo : Fix  then imagen path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
                ? $"https://https://localhost:5001//images/noimage.png"
                : $"https://vehicleszulu.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de Usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirtName} {LastName}";

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
