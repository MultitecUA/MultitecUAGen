
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_NotificacionMensaje_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionMensajeCP : BasicCP
{
public void Destroy (int p_NotificacionMensaje_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_NotificacionMensaje_destroy) ENABLED START*/

        INotificacionMensajeCAD notificacionMensajeCAD = null;
        NotificacionMensajeCEN notificacionMensajeCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionMensajeCAD = new NotificacionMensajeCAD (session);
                notificacionMensajeCEN = new  NotificacionMensajeCEN (notificacionMensajeCAD);




                notificacionMensajeCAD.Destroy (p_NotificacionMensaje_OID);


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
