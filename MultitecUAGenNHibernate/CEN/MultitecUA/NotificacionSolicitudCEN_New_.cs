
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionSolicitud_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionSolicitudCEN
{
public int New_ (string p_titulo, string p_mensaje, int p_solicitudGeneradora)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionSolicitud_new__customized) ENABLED START*/

        NotificacionSolicitudEN notificacionSolicitudEN = null;

        int oid;

        //Initialized NotificacionSolicitudEN
        notificacionSolicitudEN = new NotificacionSolicitudEN ();
        notificacionSolicitudEN.Titulo = p_titulo;

        notificacionSolicitudEN.Mensaje = p_mensaje;


        if (p_solicitudGeneradora != -1) {
                notificacionSolicitudEN.SolicitudGeneradora = new MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN ();
                notificacionSolicitudEN.SolicitudGeneradora.Id = p_solicitudGeneradora;
        }

        notificacionSolicitudEN.Fecha = DateTime.Now;

        //Call to NotificacionSolicitudCAD

        oid = _INotificacionSolicitudCAD.New_ (notificacionSolicitudEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
