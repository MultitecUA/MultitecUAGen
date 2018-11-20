
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
 * Clase Noticia:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NoticiaCAD : BasicCAD, INoticiaCAD
{
public NoticiaCAD() : base ()
{
}

public NoticiaCAD(ISession sessionAux) : base (sessionAux)
{
}



public NoticiaEN ReadOIDDefault (int id
                                 )
{
        NoticiaEN noticiaEN = null;

        try
        {
                SessionInitializeTransaction ();
                noticiaEN = (NoticiaEN)session.Get (typeof(NoticiaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return noticiaEN;
}

public System.Collections.Generic.IList<NoticiaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NoticiaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NoticiaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NoticiaEN>();
                        else
                                result = session.CreateCriteria (typeof(NoticiaEN)).List<NoticiaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), noticia.Id);

                noticiaEN.Titulo = noticia.Titulo;


                noticiaEN.Cuerpo = noticia.Cuerpo;


                noticiaEN.Foto = noticia.Foto;


                noticiaEN.Fecha = noticia.Fecha;

                session.Update (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (noticia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return noticia.Id;
}

public void Modify (NoticiaEN noticia)
{
        try
        {
                SessionInitializeTransaction ();
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), noticia.Id);

                noticiaEN.Titulo = noticia.Titulo;


                noticiaEN.Cuerpo = noticia.Cuerpo;


                noticiaEN.Foto = noticia.Foto;


                noticiaEN.Fecha = noticia.Fecha;

                session.Update (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
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
                NoticiaEN noticiaEN = (NoticiaEN)session.Load (typeof(NoticiaEN), id);
                session.Delete (noticiaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN> DameNUltimasNoticias (int ? p_n)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NoticiaEN self where select (en) FROM NoticiaEN en order by en.Fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NoticiaENdameNUltimasNoticiasHQL");
                query.SetParameter ("p_n", p_n);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NoticiaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
