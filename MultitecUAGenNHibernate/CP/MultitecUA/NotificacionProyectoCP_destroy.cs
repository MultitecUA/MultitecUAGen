
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_NotificacionProyecto_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionProyectoCP : BasicCP
{
public void Destroy (int p_NotificacionProyecto_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_NotificacionProyecto_destroy) ENABLED START*/

        INotificacionProyectoCAD notificacionProyectoCAD = null;
        NotificacionProyectoCEN notificacionProyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionProyectoCAD = new NotificacionProyectoCAD (session);
                notificacionProyectoCEN = new  NotificacionProyectoCEN (notificacionProyectoCAD);




                notificacionProyectoCAD.Destroy (p_NotificacionProyecto_OID);


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
