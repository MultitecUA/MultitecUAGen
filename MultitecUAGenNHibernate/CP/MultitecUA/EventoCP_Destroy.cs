
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Evento_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class EventoCP : BasicCP
{
public void Destroy (int p_Evento_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Evento_destroy) ENABLED START*/

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;
        EventoEN eventoEN = null;



        try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new  EventoCEN (eventoCAD);
                eventoEN = eventoCAD.ReadOID (p_Evento_OID);

                NotificacionCEN notificacionCEN = new NotificacionCEN ();
                int OID_notificacionEvento = notificacionCEN.New_ ("Evento eliminado", "El evento " + eventoEN.Nombre + " ha sido cancelado");

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

                // Eliminar todos las relaciones entre proyectos presentados a este evento
                ProyectoCP proyectoCP = new ProyectoCP ();
                foreach (ProyectoEN proyectoEN in proyectoCEN.DameProyectosPorEvento (p_Evento_OID)) {
                        proyectoCP.EliminaEventos (proyectoEN.Id, new List<int> { p_Evento_OID });
                }



                eventoCAD.Destroy (p_Evento_OID);


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
