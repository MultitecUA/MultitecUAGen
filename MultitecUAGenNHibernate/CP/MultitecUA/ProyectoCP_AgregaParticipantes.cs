
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaParticipantes) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void AgregaParticipantes (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaParticipantes) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);

                ProyectoEN proyectoEN = proyectoCAD.ReadOIDDefault (p_Proyecto_OID);


                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN ();
                int OID_notificacionProyecto = notificacionProyectoCEN.New_ ("Nuevos miembros en el proyecto", "El proyecto " + proyectoEN.Nombre + " ha admitido nuevo(s) miembro(s)", proyectoEN.Id);

                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();
                UsuarioCAD usuarioCAD = new UsuarioCAD ();

                foreach (UsuarioEN usuario in usuarioCAD.DameModeradoresProyecto (p_Proyecto_OID))
                        notificacionUsuarioCEN.New_ (usuario.Id, OID_notificacionProyecto);



                //Call to ProyectoCAD

                proyectoCAD.AgregaParticipantes (p_Proyecto_OID, p_usuariosParticipantes_OIDs);



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
