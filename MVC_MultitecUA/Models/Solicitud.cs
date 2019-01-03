using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MultitecUA.Models
{
    public class Solicitud
    {



        [ScaffoldColumn(false)] //para que no se muestre
        public string Id { get; set; }
        
        public string IdSolicitante { get; set; }
        
        [Display(Prompt = "Nick del solicitante", Description = "Nick del solicitante", Name = "Nick ")]
        [Required(ErrorMessage = "Debe indicar un nick valido")]
        [StringLength(maximumLength: 90, ErrorMessage = "El nick no puede tener más de 90 caracteres")]
        [RegularExpression("^[A-Za-z0-9 ñáéíóú]{2,}$", ErrorMessage = "El nombre solo puede contener letras, números y espacios. Mínimo 2 caracteres")]
        public string Nick_Solicitante { get; set; }

        public string Nombre_Solicitante { get; set; }
        public string Email_Solicitante { get; set; }

        public string IdProyecto { get; set; }

        [Display(Prompt = "Nombre del proyecto", Description = "Nombre del proyecto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre valido")]
        [StringLength(maximumLength: 90, ErrorMessage = "El nombre no puede tener más de 90 caracteres")]
        [RegularExpression("^[A-Za-z0-9 ñáéíóú]{2,}$", ErrorMessage = "El nombre solo puede contener letras, números y espacios. Mínimo 2 caracteres")]
        public string Nombre_Proyecto { get; set; }


        public string Estado_Proyecto { get; set; }

        public string Estado { get; set; }
        public string Fecha { get; set; }





        [Display(Prompt = "Titulo del recuerdo", Description = "Titulo del recuerdo", Name = "Titulo ")]
        [Required(ErrorMessage = "Debe indicar un titulo para el recuerdo")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        [RegularExpression("^[A-Za-z0-9 ñáéíóú]{5,}$", ErrorMessage = "El nombre solo puede contener letras, números y espacios. Mínimo 5 caracteres")]
        public string Titulo { get; set; }

        [Display(Prompt = "Cuerpo del recuerdo", Description = "Cuerpo del recuerdo", Name = "Cuerpo ")]
        [Required(ErrorMessage = "Debe escribir cuerpo para el recuerdo")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        [RegularExpression("^.{20,}$", ErrorMessage = "El nombre solo puede contener letras, números y espacios. Mínimo 20 caracteres.")]
        public string Cuerpo { get; set; }

        [Display(Prompt = "Este recuerdo es de este evento", Description = "Este recuerdo es de este evento", Name = "Id_Evento ")]
        [RegularExpression("^[0-9]$", ErrorMessage = "Las ID se componen solo de números")]
        [Required(ErrorMessage = "Debe poner una ID de evento")]
        public int IdEvento { get; set; }

        [Display(Prompt = "Este recuerdo es de este evento", Description = "Este recuerdo es de este evento", Name = "Nombre del Evento ")]
        public string NombreEvento { get; set; }



        //[Display(Prompt = "Fotos del servicio", Description = "Descripción del servicio", Name = "Fotos ")]
        //[Required(ErrorMessage = "Debe indicar una descripción para el servicio")]
        //public IList<String> Fotos { get; set; }


    }
}