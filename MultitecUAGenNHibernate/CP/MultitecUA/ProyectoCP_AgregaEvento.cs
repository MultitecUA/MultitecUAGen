
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaEvento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void AgregaEvento (int p_Proyecto_OID, int p_eventoAsociado_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_agregaEvento) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);






                //Call to ProyectoCAD

                proyectoCAD.AgregaEvento (p_Proyecto_OID, p_eventoAsociado_OID);



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
