
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaParticipante) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void AgregaParticipante (int p_Proyecto_OID, int p_usuario)
{
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaParticipante) ENABLED START*/

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
                int OID_notificacionProyecto = notificacionProyectoCEN.New_("Nuevo miembro en el proyecto", "El proyecto " + proyectoEN.Nombre + " ha aceptado un nuevo miembro", proyectoEN.Id);

                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
                UsuarioCAD usuarioCAD = new UsuarioCAD();

                foreach (UsuarioEN usuario in usuarioCAD.DameModeradoresProyecto(p_Proyecto_OID))
                    notificacionUsuarioCEN.New_(usuario.Id, OID_notificacionProyecto);


                //Call to ProyectoCAD

                proyectoCAD.AgregaParticipante (p_Proyecto_OID, p_usuario);



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
