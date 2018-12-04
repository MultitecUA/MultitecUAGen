
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_aceptar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class SolicitudCEN
{
public void Aceptar (int p_oid)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_aceptar) ENABLED START*/

        SolicitudCAD solicitudCAD = new SolicitudCAD ();
        SolicitudEN solicitudEN = solicitudCAD.ReadOIDDefault (p_oid);

        solicitudEN.Estado = Enumerated.MultitecUA.EstadoSolicitudEnum.Aceptada;


            NotificacionSolicitudCEN notificacionSolicitudCEN = new NotificacionSolicitudCEN();
            int OID_notificacionSolicitud = notificacionSolicitudCEN.New_("Solicitud Aceptada", "Tu solicitud ha sido aceptada", p_oid);

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
            notificacionUsuarioCEN.New_(solicitudEN.UsuarioSolicitante.Id, OID_notificacionSolicitud);

            ProyectoCP proyectoCP = new ProyectoCP();
            proyectoCP.AgregaParticipantes(solicitudEN.ProyectoSolicitado.Id, new List<int> { solicitudEN.UsuarioSolicitante.Id });

            solicitudCAD.ModifyDefault (solicitudEN);

        /*PROTECTED REGION END*/
}
}
}
