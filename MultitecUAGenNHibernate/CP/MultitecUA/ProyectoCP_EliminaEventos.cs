
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaEventos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void EliminaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaEventos) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);
                ProyectoEN proyectoEN = proyectoCAD.ReadOID (p_Proyecto_OID);

                EventoCEN eventoCEN = new EventoCEN ();
                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN ();
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                foreach (int OID_Evento in p_eventosAsociados_OIDs) {
                        EventoEN eventoEN = eventoCEN.ReadOID (OID_Evento);

                        int OID_notificacionProyecto = notificacionProyectoCEN.New_ ("Proyecto retirado de evento", "El proyecto " + proyectoEN.Nombre + " se ha retirado del evento " + eventoEN.Nombre, proyectoEN.Id);

                        foreach (UsuarioEN usuario in usuarioCEN.DameParticipantesProyecto (p_Proyecto_OID))
                                notificacionUsuarioCEN.New_ (usuario.Id, OID_notificacionProyecto);
                }




                //Call to ProyectoCAD

                proyectoCAD.EliminaEventos (p_Proyecto_OID, p_eventosAsociados_OIDs);



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
