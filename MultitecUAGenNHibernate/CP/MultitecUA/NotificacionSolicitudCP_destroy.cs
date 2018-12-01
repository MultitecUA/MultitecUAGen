
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_NotificacionSolicitud_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionSolicitudCP : BasicCP
{
public void Destroy (int p_NotificacionSolicitud_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_NotificacionSolicitud_destroy) ENABLED START*/

        INotificacionSolicitudCAD notificacionSolicitudCAD = null;
        NotificacionSolicitudCEN notificacionSolicitudCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionSolicitudCAD = new NotificacionSolicitudCAD (session);
                notificacionSolicitudCEN = new  NotificacionSolicitudCEN (notificacionSolicitudCAD);




                notificacionSolicitudCAD.Destroy (p_NotificacionSolicitud_OID);


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
