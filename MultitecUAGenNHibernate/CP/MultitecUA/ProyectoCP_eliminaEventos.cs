
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaEventos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ProyectoCP : BasicCP
{
public void EliminaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Proyecto_eliminaEventos) ENABLED START*/

        IProyectoCAD proyectoCAD = null;
        ProyectoCEN proyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                proyectoCAD = new ProyectoCAD (session);
                proyectoCEN = new  ProyectoCEN (proyectoCAD);






                //Call to ProyectoCAD

                proyectoCAD.EliminaEventos (p_Proyecto_OID, p_eventosAsociados_OIDs);



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
