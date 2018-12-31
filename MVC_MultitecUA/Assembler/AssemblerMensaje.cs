using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerMensajeModel
    {
        public MensajeModel ConvertENToModelUI(MensajeEN mensaje)
        {
            MensajeModel mensj = new MensajeModel();
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioENAutor = usuarioCEN.ReadOID(mensaje.UsuarioAutor.Id);
            UsuarioEN usuarioENReceptor = usuarioCEN.ReadOID(mensaje.UsuarioReceptor.Id);

            /* serv.Id = mensaje.Id.ToString();
             serv.Nombre = mensaje.Nombre;
             serv.Descripcion = mensaje.Descripcion;
             serv.Estado = mensaje.Estado;*/

            mensj.Id = mensaje.Id;
            mensj.Titulo = mensaje.Titulo;
            mensj.Cuerpo = mensaje.Cuerpo;
            mensj.EstadoLectura = mensaje.EstadoLecutra.ToString();
            mensj.Fecha = mensaje.Fecha.ToString();
            mensj.AutorId = mensaje.UsuarioAutor.Id;
            mensj.ReceptorId = mensaje.UsuarioReceptor.Id;
            mensj.NombreAutor = usuarioENAutor.Nombre;
            mensj.NombreReceptor = usuarioENReceptor.Nombre;
            mensj.NickAutor = usuarioENAutor.Nick;
            mensj.NickReceptor = usuarioENReceptor.Nick;
            mensj.BandejaAutor = mensaje.BandejaAutor.ToString();
            mensj.BandejaReceptor = mensaje.BandejaReceptor.ToString();

            return mensj;

        }

        public IList<MensajeModel> ConvertListENToModel (IList<MensajeEN> ens){
            IList<MensajeModel> mensajes = new List<MensajeModel>();
            foreach (MensajeEN en in ens)
            {
                mensajes.Add(ConvertENToModelUI(en));
            }
            return mensajes;
        }
        
    }
}