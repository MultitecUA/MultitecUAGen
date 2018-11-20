
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaModeradores) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void AgregaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_Usuarios_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaModeradores) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;
        ProyectoEN proyectoEN = null;


            try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);
                proyectoEN = proyectoCAD.ReadOIDDefault(p_Proyecto_OID);

                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN();
                int OID_notificacionProyecto = notificacionProyectoCEN.New_("Nuevo moderador en el proyecto", "El proyecto " + proyectoEN.Nombre + " tiene un nuevo moderador", proyectoEN.Id);

                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
                UsuarioCAD usuarioCAD = new UsuarioCAD();

                foreach (UsuarioEN usuario in usuarioCAD.DameModeradoresProyecto(p_Proyecto_OID))
                    notificacionUsuarioCEN.New_(usuario.Id, OID_notificacionProyecto);



                //Call to ProyectoCAD

                proyectoCAD.AgregaModeradores (p_Proyecto_OID, p_Usuarios_OIDs);



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
