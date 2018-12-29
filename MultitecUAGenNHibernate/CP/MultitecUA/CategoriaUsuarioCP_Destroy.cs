
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_CategoriaUsuario_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class CategoriaUsuarioCP : BasicCP
{
public void Destroy (int p_CategoriaUsuario_OID)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_CategoriaUsuario_destroy) ENABLED START*/

        ICategoriaUsuarioCAD categoriaUsuarioCAD = null;
        CategoriaUsuarioCEN categoriaUsuarioCEN = null;
        CategoriaUsuarioEN categoriaUsuarioEN = null;



        try
        {
                SessionInitializeTransaction ();
                categoriaUsuarioCAD = new CategoriaUsuarioCAD (session);
                categoriaUsuarioCEN = new  CategoriaUsuarioCEN (categoriaUsuarioCAD);
                categoriaUsuarioEN = categoriaUsuarioCEN.ReadOID (p_CategoriaUsuario_OID);


                ProyectoCEN proyectoCEN = new ProyectoCEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                List<int> OIDCategoriaABorrar = new List<int>();
                OIDCategoriaABorrar.Add (p_CategoriaUsuario_OID);

                foreach (ProyectoEN proyectoEN in proyectoCEN.DameProyectosPorCategoriaUsuario (p_CategoriaUsuario_OID))
                        proyectoCEN.EliminaCategoriasUsuario (proyectoEN.Id, OIDCategoriaABorrar);

                foreach (UsuarioEN usuarioEN in usuarioCEN.DameUsuariosPorCategoria (p_CategoriaUsuario_OID))
                        usuarioCEN.EliminaCategorias (usuarioEN.Id, OIDCategoriaABorrar);



                categoriaUsuarioCAD.Destroy (p_CategoriaUsuario_OID);


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
