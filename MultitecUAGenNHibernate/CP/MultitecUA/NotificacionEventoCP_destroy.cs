
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_NotificacionEvento_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionEventoCP : BasicCP
{
public void Destroy (int p_NotificacionEvento_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_NotificacionEvento_destroy) ENABLED START*/

        INotificacionEventoCAD notificacionEventoCAD = null;
        NotificacionEventoCEN notificacionEventoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionEventoCAD = new NotificacionEventoCAD (session);
                notificacionEventoCEN = new  NotificacionEventoCEN (notificacionEventoCAD);




                notificacionEventoCAD.Destroy (p_NotificacionEvento_OID);


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
