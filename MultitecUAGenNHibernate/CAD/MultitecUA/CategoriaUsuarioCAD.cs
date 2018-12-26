
using System;
using System.Text;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.Exceptions;


/*
 * Clase CategoriaUsuario:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class CategoriaUsuarioCAD : BasicCAD, ICategoriaUsuarioCAD
{
public CategoriaUsuarioCAD() : base ()
{
}

public CategoriaUsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaUsuarioEN ReadOIDDefault (int id
                                          )
{
        CategoriaUsuarioEN categoriaUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaUsuarioEN = (CategoriaUsuarioEN)session.Get (typeof(CategoriaUsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaUsuarioEN;
}

public System.Collections.Generic.IList<CategoriaUsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaUsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaUsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaUsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaUsuarioEN)).List<CategoriaUsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaUsuarioEN categoriaUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaUsuarioEN categoriaUsuarioEN = (CategoriaUsuarioEN)session.Load (typeof(CategoriaUsuarioEN), categoriaUsuario.Id);

                categoriaUsuarioEN.Nombre = categoriaUsuario.Nombre;



                session.Update (categoriaUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CategoriaUsuarioEN categoriaUsuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoriaUsuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaUsuario.Id;
}

public void Modify (CategoriaUsuarioEN categoriaUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaUsuarioEN categoriaUsuarioEN = (CategoriaUsuarioEN)session.Load (typeof(CategoriaUsuarioEN), categoriaUsuario.Id);

                categoriaUsuarioEN.Nombre = categoriaUsuario.Nombre;

                session.Update (categoriaUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaUsuarioEN categoriaUsuarioEN = (CategoriaUsuarioEN)session.Load (typeof(CategoriaUsuarioEN), id);
                session.Delete (categoriaUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CategoriaUsuarioEN
public CategoriaUsuarioEN ReadOID (int id
                                   )
{
        CategoriaUsuarioEN categoriaUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaUsuarioEN = (CategoriaUsuarioEN)session.Get (typeof(CategoriaUsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaUsuarioEN;
}

public System.Collections.Generic.IList<CategoriaUsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaUsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaUsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaUsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaUsuarioEN)).List<CategoriaUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN ReadNombre (string p_nombre)
{
        MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CategoriaUsuarioEN self where select (en) FROM CategoriaUsuarioEN en where en.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CategoriaUsuarioENreadNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
