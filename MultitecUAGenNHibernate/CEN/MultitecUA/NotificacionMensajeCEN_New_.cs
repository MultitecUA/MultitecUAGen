
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionMensaje_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionMensajeCEN
{
public int New_ (string p_titulo, string p_mensaje, int p_mensajeGenerador)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionMensaje_new__customized) START*/

        NotificacionMensajeEN notificacionMensajeEN = null;

        int oid;

        //Initialized NotificacionMensajeEN
        notificacionMensajeEN = new NotificacionMensajeEN ();
        notificacionMensajeEN.Titulo = p_titulo;

        notificacionMensajeEN.Mensaje = p_mensaje;


        if (p_mensajeGenerador != -1) {
                notificacionMensajeEN.MensajeGenerador = new MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN ();
                notificacionMensajeEN.MensajeGenerador.Id = p_mensajeGenerador;
        }

        //Call to NotificacionMensajeCAD

        oid = _INotificacionMensajeCAD.New_ (notificacionMensajeEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
