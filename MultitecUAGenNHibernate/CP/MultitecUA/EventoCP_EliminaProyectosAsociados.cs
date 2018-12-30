
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Evento_eliminaProyectosAsociados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class EventoCP : BasicCP
{
public void EliminaProyectosAsociados (int p_Evento_OID, System.Collections.Generic.IList<int> p_proyectosPresentados_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Evento_eliminaProyectosAsociados) ENABLED START*/

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;
        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



            try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new  EventoCEN (eventoCAD);

                proyectoCAD = new ProyectoCAD(session);
                proyectoCEN = new ProyectoCEN(proyectoCAD);



                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN();
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
                UsuarioCEN usuarioCEN = new UsuarioCEN();

                foreach (int OID_Evento in p_proyectosPresentados_OIDs)
                {
                    ProyectoEN proyectoEN = proyectoCAD.ReadOID(OID_Evento);

                    EventoEN eventoEN = eventoCEN.ReadOID(OID_Evento);

                    int OID_notificacionProyecto = notificacionProyectoCEN.New_("Proyecto retirado de evento", "El proyecto " + proyectoEN.Nombre + " ha sido retirado del evento " + eventoEN.Nombre + " por un administrador", proyectoEN.Id);

                    foreach (UsuarioEN usuario in usuarioCEN.DameModeradoresProyecto(OID_Evento))
                        notificacionUsuarioCEN.New_(usuario.Id, OID_notificacionProyecto);
                }




                //Call to EventoCAD

                eventoCAD.EliminaProyectosAsociados (p_Evento_OID, p_proyectosPresentados_OIDs);



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
