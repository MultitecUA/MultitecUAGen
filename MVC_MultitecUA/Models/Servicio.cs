﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MultitecUA.Models
{
    public class Servicio
    {



        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Display(Prompt = "Nombre del servicio", Description = "Nombre del servicio", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el servicio")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del servicio", Description = "Descripción del servicio", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el servicio")]
        [StringLength(maximumLength: 4000, ErrorMessage = "La descripción no puede tener más de 4000 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Estado del servicio", Description = "Estado del servicio", Name = "Estado ")]
        [Required(ErrorMessage = "Debe indicar un estado para el servicio")]
        public MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum Estado { get; set; }

        //[Display(Prompt = "Fotos del servicio", Description = "Descripción del servicio", Name = "Fotos ")]
        //[Required(ErrorMessage = "Debe indicar una descripción para el servicio")]
        //public IList<String> Fotos { get; set; }


    }
}