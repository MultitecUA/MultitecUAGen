
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Usuario_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class UsuarioCP : BasicCP
{
public void Destroy (int p_Usuario_OID)
{
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Usuario_destroy) ENABLED START*/

            IUsuarioCAD usuarioCAD = null;
            IMensajeCAD mensajeCAD = null;
            IProyectoCAD proyectoCAD = null;
            INotificacionUsuarioCAD notificacionUsuarioCAD = null;



            try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                mensajeCAD = new MensajeCAD(session);
                proyectoCAD = new ProyectoCAD(session);
                notificacionUsuarioCAD = new NotificacionUsuarioCAD(session);

                if (mensajeCAD.DameMensajesPorAutor(p_Usuario_OID).Count == 0)
                    if (mensajeCAD.DameMensajesPorReceptor(p_Usuario_OID).Count == 0)
                        if (proyectoCAD.DameProyectosUsuarioPertenece(p_Usuario_OID).Count == 0)
                            if (notificacionUsuarioCAD.DameNotificacionesPorUsuario(p_Usuario_OID).Count == 0)


                                usuarioCAD.Destroy (p_Usuario_OID);


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
