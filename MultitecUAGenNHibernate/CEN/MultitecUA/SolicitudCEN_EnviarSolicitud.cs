
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_enviarSolicitud) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class SolicitudCEN
{
public void EnviarSolicitud (int p_oid)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_enviarSolicitud) ENABLED START*/

        // Write here your custom code...

        SolicitudCEN solicitudCEN = new SolicitudCEN ();
        SolicitudEN solicitudEN = solicitudCEN.ReadOID (p_oid);   //conseguimos solicitud entera


        NotificacionSolicitudCEN notificacionSolicitudCEN = new NotificacionSolicitudCEN ();
        int OID_notificacionSolicitud = notificacionSolicitudCEN.New_ ("Nueva Solicitud", "Usiario pendiente de aceptacion", p_oid);

        NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();

        UsuarioCEN usuarioCEN = new UsuarioCEN ();

        ProyectoCEN proyectoCEN = new ProyectoCEN ();
        ProyectoEN proyectoEN = proyectoCEN.ReadOID (solicitudEN.ProyectoSolicitado.Id);

        foreach (UsuarioEN e in usuarioCEN.DameModeradoresProyecto (proyectoEN.Id)) {
                notificacionUsuarioCEN.New_ (e.Id, OID_notificacionSolicitud);
        }


        /*PROTECTED REGION END*/
}
}
}
