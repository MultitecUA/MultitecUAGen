
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
 * Clase CategoriaProyecto:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class CategoriaProyectoCAD : BasicCAD, ICategoriaProyectoCAD
{
public CategoriaProyectoCAD() : base ()
{
}

public CategoriaProyectoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaProyectoEN ReadOIDDefault (int id
                                           )
{
        CategoriaProyectoEN categoriaProyectoEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaProyectoEN = (CategoriaProyectoEN)session.Get (typeof(CategoriaProyectoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaProyectoEN;
}

public System.Collections.Generic.IList<CategoriaProyectoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaProyectoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaProyectoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaProyectoEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaProyectoEN)).List<CategoriaProyectoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaProyectoEN categoriaProyecto)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaProyectoEN categoriaProyectoEN = (CategoriaProyectoEN)session.Load (typeof(CategoriaProyectoEN), categoriaProyecto.Id);

                categoriaProyectoEN.Nombre = categoriaProyecto.Nombre;



                session.Update (categoriaProyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CategoriaProyectoEN categoriaProyecto)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoriaProyecto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaProyecto.Id;
}

public void Modify (CategoriaProyectoEN categoriaProyecto)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaProyectoEN categoriaProyectoEN = (CategoriaProyectoEN)session.Load (typeof(CategoriaProyectoEN), categoriaProyecto.Id);

                categoriaProyectoEN.Nombre = categoriaProyecto.Nombre;

                session.Update (categoriaProyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
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
                CategoriaProyectoEN categoriaProyectoEN = (CategoriaProyectoEN)session.Load (typeof(CategoriaProyectoEN), id);
                session.Delete (categoriaProyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
