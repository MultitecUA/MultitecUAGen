using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MultitecUA.Models
{
    public class Recuerdo
    {


        [ScaffoldColumn(false)]
        public string Id { get; set; }

        
        [Display(Prompt = "Titulo del recuerdo", Description = "Titulo del recuerdo", Name = "Titulo ")]
        [Required(ErrorMessage = "Debe indicar un titulo para el recuerdo")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        [RegularExpression("^[A-Za-z0-9 ñáéíóú]{5,}$", ErrorMessage = "El nombre solo puede contener letras, números y espacios. Mínimo 5 caracteres")]
        public string Titulo { get; set; }

        [Display(Prompt = "Cuerpo del recuerdo", Description = "Cuerpo del recuerdo", Name = "Cuerpo ")]
        [Required(ErrorMessage = "Debe escribir cuerpo para el recuerdo")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        [RegularExpression("^.{20,}$", ErrorMessage = "El cuerpo del recuerdo solo puede contener letras, números y espacios. Mínimo 20 caracteres.")]
        public string Cuerpo { get; set; }

        [Display(Prompt = "Este recuerdo es de este evento", Description = "Este recuerdo es de este evento", Name = "Id_Evento ")]
        [Required(ErrorMessage = "Debe poner una ID de evento")]
        public int IdEvento { get; set; }

        [Display(Prompt = "Este recuerdo es de este evento", Description = "Este recuerdo es de este evento", Name = "Nombre del Evento ")]
        public string NombreEvento { get; set; }

    }
}