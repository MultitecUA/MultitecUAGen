using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MultitecUA.Models
{
    public class MensajeModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        /*[ScaffoldColumn(false)]*/
        public int AutorId { get; set; }

        /*[ScaffoldColumn(false)]*/
        public int ReceptorId { get; set; }

        //[Display(Prompt = "Título del mensaje", Description = "Título del mensaje", Name = "Título ")]
        //[Required(ErrorMessage = "Debe indicar un título para el mensaje")]
       // [StringLength(maximumLength: 100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Titulo { get; set; }

        //[Display(Prompt = "Cuerpo del mensaje", Description = "Cuerpo del mensaje", Name = "Cuerpo ")]
        //[Required(ErrorMessage = "Debe indicar un cuerpo para el mensaje")]
        //[StringLength(maximumLength: 4000, ErrorMessage = "El cuerpo del mensaje no puede tener más de 4000 caracteres")]
        public string Cuerpo { get; set; }

        public string Fecha { get; set; }

        public string NombreAutor { get; set; }
        [Display(Prompt = "Nick del autor", Description = "Nick del autor", Name = "Nick autor")]
        [Required(ErrorMessage = "Debe indicar un nick valido")]
        [StringLength(maximumLength: 90, ErrorMessage = "El nick no puede tener más de 90 caracteres")]
        public string NickAutor { get; set; }
        public string NombreReceptor { get; set; }
        [Display(Prompt = "Nick del receptor", Description = "Nick del receptor", Name = "Nick receptor")]
        [Required(ErrorMessage = "Debe indicar un nick valido")]
        [StringLength(maximumLength: 90, ErrorMessage = "El nick no puede tener más de 90 caracteres")]
        public string NickReceptor { get; set; }
        public string EstadoLectura { get; set; }
        public string BandejaAutor { get; set; }
        public string BandejaReceptor { get; set; }

    }
}