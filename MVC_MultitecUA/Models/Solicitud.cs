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
        public string Nick_Solicitante { get; set; }

        public string Nombre_Solicitante { get; set; }
        public string Email_Solicitante { get; set; }

        public string IdProyecto { get; set; }

        [Display(Prompt = "Nombre del proyecto", Description = "Nombre del proyecto", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre valido")]
        [StringLength(maximumLength: 90, ErrorMessage = "El nombre no puede tener más de 90 caracteres")]
        public string Nombre_Proyecto { get; set; }


        public string Estado_Proyecto { get; set; }

        public string Estado { get; set; }
        public string Fecha { get; set; }



        
      

     
        

        //[Display(Prompt = "Fotos del servicio", Description = "Descripción del servicio", Name = "Fotos ")]
        //[Required(ErrorMessage = "Debe indicar una descripción para el servicio")]
        //public IList<String> Fotos { get; set; }


    }
}