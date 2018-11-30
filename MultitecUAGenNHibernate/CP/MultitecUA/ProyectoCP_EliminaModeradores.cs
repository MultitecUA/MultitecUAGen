
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaModeradores) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void EliminaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosModeradores_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaModeradores) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;
        ProyectoEN proyectoEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new ProyectoCEN (proyectoCAD);
                proyectoEN = proyectoCAD.ReadOIDDefault (p_Proyecto_OID);

                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN ();
                int OID_notificacionProyecto = notificacionProyectoCEN.New_ ("Moderadores eliminados del proyecto", "Han habido cambios en los moderadores del proyecto " + proyectoEN.Nombre, proyectoEN.Id);

                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                foreach (UsuarioEN usuario in usuarioCEN.DameModeradoresProyecto (p_Proyecto_OID))
                        notificacionUsuarioCEN.New_ (usuario.Id, OID_notificacionProyecto);



                //Call to ProyectoCAD

                proyectoCAD.EliminaModeradores (p_Proyecto_OID, p_usuariosModeradores_OIDs);



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
