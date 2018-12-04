
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void Destroy (int p_Proyecto_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_destroy) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);

                ProyectoEN proyectoEN = proyectoCAD.ReadOID (p_Proyecto_OID);

                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                List<int> moderadores = new List<int>();
                foreach (UsuarioEN moderador in usuarioCEN.DameModeradoresProyecto (p_Proyecto_OID)) {
                        moderadores.Add (moderador.Id);
                }
                proyectoCAD.EliminaModeradores (p_Proyecto_OID, moderadores);

                List<int> participantes = new List<int>();
                foreach (UsuarioEN participante in usuarioCEN.DameParticipantesProyecto (p_Proyecto_OID)) {
                        participantes.Add (participante.Id);
                }
                proyectoCAD.EliminaParticipantes (p_Proyecto_OID, participantes);


                NotificacionCEN notificacionCEN = new NotificacionCEN ();
                int OID_notificacion = notificacionCEN.New_ ("Proyecto eliminado", "El proyecto " + proyectoEN.Nombre + " ha sido eliminado");

                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();

                foreach (UsuarioEN usuario in usuarioCEN.DameParticipantesProyecto (p_Proyecto_OID))
                        notificacionUsuarioCEN.New_ (usuario.Id, OID_notificacion);

                SolicitudCEN solicitudCEN = new SolicitudCEN ();
                foreach (SolicitudEN solicitud in solicitudCEN.DameSolicitudesPorProyectoYEstado (p_Proyecto_OID, Enumerated.MultitecUA.EstadoSolicitudEnum.Pendiente)) {
                        notificacionUsuarioCEN.New_ (solicitud.UsuarioSolicitante.Id, OID_notificacion);
                }

                EventoCEN eventoCEN = new EventoCEN ();
                foreach (EventoEN eventoEN in eventoCEN.DameEventosPorProyecto (p_Proyecto_OID))
                        eventoCEN.EliminaProyectosAsociados (eventoEN.Id, new List<int> { p_Proyecto_OID });

                proyectoCAD.Destroy (p_Proyecto_OID);


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
