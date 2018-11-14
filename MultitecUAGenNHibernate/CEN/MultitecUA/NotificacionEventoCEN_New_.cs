
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionEvento_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionEventoCEN
{
public int New_ (string p_titulo, string p_mensaje, int p_eventoGenerador)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionEvento_new__customized) ENABLED START*/

        NotificacionEventoEN notificacionEventoEN = null;

        int oid;

        //Initialized NotificacionEventoEN
        notificacionEventoEN = new NotificacionEventoEN ();
        notificacionEventoEN.Titulo = p_titulo;

        notificacionEventoEN.Mensaje = p_mensaje;


        if (p_eventoGenerador != -1) {
                notificacionEventoEN.EventoGenerador = new MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ();
                notificacionEventoEN.EventoGenerador.Id = p_eventoGenerador;
        }

        notificacionEventoEN.Fecha = DateTime.Now;

        //Call to NotificacionEventoCAD

        oid = _INotificacionEventoCAD.New_ (notificacionEventoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
