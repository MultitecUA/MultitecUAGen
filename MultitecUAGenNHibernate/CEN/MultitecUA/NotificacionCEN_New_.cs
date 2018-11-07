
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Notificacion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionCEN
{
public int New_ (string p_titulo, string p_mensaje)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Notificacion_new__customized) START*/

        NotificacionEN notificacionEN = null;

        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Titulo = p_titulo;

        notificacionEN.Mensaje = p_mensaje;

        //Call to NotificacionCAD

        oid = _INotificacionCAD.New_ (notificacionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
