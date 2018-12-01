
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Notificacion_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionCP : BasicCP
{
public void Destroy (int p_Notificacion_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Notificacion_destroy) ENABLED START*/

        INotificacionCAD notificacionCAD = null;
        NotificacionCEN notificacionCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionCAD = new NotificacionCAD (session);
                notificacionCEN = new  NotificacionCEN (notificacionCAD);




                notificacionCAD.Destroy (p_Notificacion_OID);


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
