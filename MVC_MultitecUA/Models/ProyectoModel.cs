using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MultitecUA.Models
{
    public class ProyectoModel
    {

        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Display(Prompt = "Usuario creador del proyecto", Description = "Usuario creador del proyecto", Name = "Creador ")]
        [Required(ErrorMessage = "Debe indicar un creador del proyecto")]
        public int usuarioId { get; set; }

        [Display(Prompt = "Nombre del proyecto", Description = "Nombre del proyecto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el proyecto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del proyecto", Description = "Descripción del proyecto", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el proyecto")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        public string Descripcion { get; set; }

    }
}