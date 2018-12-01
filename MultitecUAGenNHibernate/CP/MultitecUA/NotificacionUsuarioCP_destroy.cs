
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_NotificacionUsuario_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NotificacionUsuarioCP : BasicCP
{
public void Destroy (int p_NotificacionUsuario_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_NotificacionUsuario_destroy) ENABLED START*/

        INotificacionUsuarioCAD notificacionUsuarioCAD = null;
        NotificacionUsuarioCEN notificacionUsuarioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                notificacionUsuarioCAD = new NotificacionUsuarioCAD (session);
                notificacionUsuarioCEN = new  NotificacionUsuarioCEN (notificacionUsuarioCAD);




                notificacionUsuarioCAD.Destroy (p_NotificacionUsuario_OID);


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
