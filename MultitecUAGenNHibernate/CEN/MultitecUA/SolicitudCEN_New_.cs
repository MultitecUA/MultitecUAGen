
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class SolicitudCEN
{
public int New_ (int p_usuarioSolicitante, int p_proyectoSolicitado)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_new__customized) ENABLED START*/
        SolicitudCAD solicitudCAD = new SolicitudCAD ();

        if (solicitudCAD.DameSolicitudesPendientesPorProyectoDe (p_proyectoSolicitado, p_usuarioSolicitante).Count == 0) {
                SolicitudEN solicitudEN = null;

                int oid;

                //Initialized SolicitudEN
                solicitudEN = new SolicitudEN ();

                if (p_usuarioSolicitante != -1) {
                        solicitudEN.UsuarioSolicitante = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                        solicitudEN.UsuarioSolicitante.Id = p_usuarioSolicitante;
                }


                if (p_proyectoSolicitado != -1) {
                        solicitudEN.ProyectoSolicitado = new MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ();
                        solicitudEN.ProyectoSolicitado.Id = p_proyectoSolicitado;
                }

                solicitudEN.Fecha = DateTime.Now;

                solicitudEN.Estado = Enumerated.MultitecUA.EstadoSolicitudEnum.Pendiente;

                //Call to SolicitudCAD

                oid = _ISolicitudCAD.New_ (solicitudEN);
                return oid;
        }
        else
                return -1;
        /*PROTECTED REGION END*/
}
}
}
