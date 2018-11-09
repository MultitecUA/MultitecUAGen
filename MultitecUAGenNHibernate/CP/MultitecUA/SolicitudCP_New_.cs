
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Solicitud_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class SolicitudCP : BasicCP
{
public MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN New_ (int p_usuarioSolicitante, int p_proyectoSolicitado)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Solicitud_new_) ENABLED START*/

        ISolicitudCAD solicitudCAD = null;
        SolicitudCEN solicitudCEN = null;

        MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN result = null;


        try
        {
                SessionInitializeTransaction ();
                solicitudCAD = new SolicitudCAD (session);
                solicitudCEN = new  SolicitudCEN (solicitudCAD);




                int oid;
                //Initialized SolicitudEN
                SolicitudEN solicitudEN;
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

                oid = solicitudCAD.New_ (solicitudEN);
                result = solicitudCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
