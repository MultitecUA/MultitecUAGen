
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_CategoriaProyecto_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class CategoriaProyectoCP : BasicCP
{
public void Destroy (int p_CategoriaProyecto_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_CategoriaProyecto_destroy) ENABLED START*/

        ICategoriaProyectoCAD categoriaProyectoCAD = null;
        CategoriaProyectoCEN categoriaProyectoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                categoriaProyectoCAD = new CategoriaProyectoCAD (session);
                categoriaProyectoCEN = new  CategoriaProyectoCEN (categoriaProyectoCAD);

                ProyectoCEN proyectoCEN = new ProyectoCEN ();
                EventoCEN eventoCEN = new EventoCEN ();

                List<int> OIDCategoriaABorrar = new List<int>();
                OIDCategoriaABorrar.Add (p_CategoriaProyecto_OID);

                foreach (ProyectoEN proyectoEN in proyectoCEN.DameProyectosPorCategoria (p_CategoriaProyecto_OID))
                        proyectoCEN.EliminaCategoriasProyecto (proyectoEN.Id, OIDCategoriaABorrar);

                foreach (EventoEN eventoEN in eventoCEN.DameEventosFiltrados (p_CategoriaProyecto_OID, null, null))
                        eventoCEN.EliminaCategorias (eventoEN.Id, OIDCategoriaABorrar);


                categoriaProyectoCAD.Destroy (p_CategoriaProyecto_OID);
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
