
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Evento_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class EventoCP : BasicCP
{
public void Modify (int p_Evento_OID, string p_nombre, string p_descripcion, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, Nullable<DateTime> p_fechaInicioInscripcion, Nullable<DateTime> p_fechaTopeInscripcion, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Evento_modify) ENABLED START*/

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new EventoCEN (eventoCAD);




                EventoEN eventoEN = null;
                //Initialized EventoEN
                eventoEN = new EventoEN ();
                eventoEN.Id = p_Evento_OID;
                eventoEN.Nombre = p_nombre;
                eventoEN.Descripcion = p_descripcion;
                eventoEN.FechaInicio = p_fechaInicio;
                eventoEN.FechaFin = p_fechaFin;
                eventoEN.FechaInicioInscripcion = p_fechaInicioInscripcion;
                eventoEN.FechaTopeInscripcion = p_fechaTopeInscripcion;
                eventoEN.Fotos = p_fotos;


                NotificacionEventoCEN notificacionEventoCEN = new NotificacionEventoCEN ();
                int OID_notificacionEvento = notificacionEventoCEN.New_ ("Evento modificado", "El evento " + eventoEN.Nombre + " ha sido modificado", eventoEN.Id);

                ProyectoCEN proyectoCEN = new ProyectoCEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();
                List<int> OIDsParticipantes = new List<int>();

                foreach (ProyectoEN proyectoEN in proyectoCEN.DameProyectosPorEvento (p_Evento_OID))
                        foreach (UsuarioEN usuario in usuarioCEN.DameParticipantesProyecto (proyectoEN.Id))
                                if (!OIDsParticipantes.Contains (usuario.Id))
                                        OIDsParticipantes.Add (usuario.Id);

                foreach (int OIDUsuario in OIDsParticipantes)
                        notificacionUsuarioCEN.New_ (OIDUsuario, OID_notificacionEvento);

                //Call to EventoCAD

                eventoCAD.Modify (eventoEN);


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
