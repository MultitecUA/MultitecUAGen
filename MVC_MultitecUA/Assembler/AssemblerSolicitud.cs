using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerSolicitud
    {
        public Solicitud ConvertENToModelUI(SolicitudEN en)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.ReadOID(en.UsuarioSolicitante.Id);

            ProyectoCEN proyectoCEN = new ProyectoCEN();
            ProyectoEN proyectoEN = proyectoCEN.ReadOID(en.ProyectoSolicitado.Id);

            Solicitud solicit = new Solicitud();

            //Datos Completos
            solicit.Id = en.Id.ToString();

            solicit.IdSolicitante = en.UsuarioSolicitante.Id.ToString();
            solicit.Nick_Solicitante = usuarioEN.Nick;
            solicit.Nombre_Solicitante = usuarioEN.Nombre;
            solicit.Email_Solicitante = usuarioEN.Email;

            solicit.IdProyecto = en.ProyectoSolicitado.Id.ToString();
            solicit.Nombre_Proyecto = proyectoEN.Nombre;
            solicit.Estado_Proyecto = proyectoEN.Estado.ToString();

            solicit.Estado = en.Estado.ToString();
            solicit.Fecha = en.Fecha.ToString();
           
            
            return solicit;


        }
        public IList<Solicitud> ConvertListENToModel (IList<SolicitudEN> ens){
            IList<Solicitud> solicit = new List<Solicitud>();
            foreach (SolicitudEN en in ens)
            {
                solicit.Add(ConvertENToModelUI(en));
            }
            return solicit;
        }
        
    }
}