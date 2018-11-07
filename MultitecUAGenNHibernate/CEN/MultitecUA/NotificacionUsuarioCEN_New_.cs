
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionUsuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionUsuarioCEN
{
public int New_ (int p_usuarioNotificado, int p_notificacionGenerada)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionUsuario_new__customized) START*/

        NotificacionUsuarioEN notificacionUsuarioEN = null;

        int oid;

        //Initialized NotificacionUsuarioEN
        notificacionUsuarioEN = new NotificacionUsuarioEN ();

        if (p_usuarioNotificado != -1) {
                notificacionUsuarioEN.UsuarioNotificado = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                notificacionUsuarioEN.UsuarioNotificado.Id = p_usuarioNotificado;
        }


        if (p_notificacionGenerada != -1) {
                notificacionUsuarioEN.NotificacionGenerada = new MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN ();
                notificacionUsuarioEN.NotificacionGenerada.Id = p_notificacionGenerada;
        }

        //Call to NotificacionUsuarioCAD

        oid = _INotificacionUsuarioCAD.New_ (notificacionUsuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
