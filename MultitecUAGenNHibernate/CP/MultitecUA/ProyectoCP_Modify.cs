
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void Modify (int p_Proyecto_OID, string p_nombre, string p_descripcion, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_modify) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);




                ProyectoEN proyectoEN = null;
                //Initialized ProyectoEN
                proyectoEN = new ProyectoEN ();
                proyectoEN.Id = p_Proyecto_OID;
                proyectoEN.Nombre = p_nombre;
                proyectoEN.Descripcion = p_descripcion;
                proyectoEN.Fotos = p_fotos;
                //Call to ProyectoCAD

                proyectoCAD.Modify (proyectoEN);


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
