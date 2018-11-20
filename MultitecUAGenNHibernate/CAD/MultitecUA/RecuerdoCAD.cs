
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
 * Clase Recuerdo:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class RecuerdoCAD : BasicCAD, IRecuerdoCAD
{
public RecuerdoCAD() : base ()
{
}

public RecuerdoCAD(ISession sessionAux) : base (sessionAux)
{
}



public RecuerdoEN ReadOIDDefault (int id
                                  )
{
        RecuerdoEN recuerdoEN = null;

        try
        {
                SessionInitializeTransaction ();
                recuerdoEN = (RecuerdoEN)session.Get (typeof(RecuerdoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recuerdoEN;
}

public System.Collections.Generic.IList<RecuerdoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RecuerdoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RecuerdoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RecuerdoEN>();
                        else
                                result = session.CreateCriteria (typeof(RecuerdoEN)).List<RecuerdoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RecuerdoEN recuerdo)
{
        try
        {
                SessionInitializeTransaction ();
                RecuerdoEN recuerdoEN = (RecuerdoEN)session.Load (typeof(RecuerdoEN), recuerdo.Id);

                recuerdoEN.Titulo = recuerdo.Titulo;


                recuerdoEN.Cuerpo = recuerdo.Cuerpo;


                recuerdoEN.Fotos = recuerdo.Fotos;


                session.Update (recuerdoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RecuerdoEN recuerdo)
{
        try
        {
                SessionInitializeTransaction ();
                if (recuerdo.EventoRecordado != null) {
                        // Argumento OID y no colección.
                        recuerdo.EventoRecordado = (MultitecUAGenNHibernate.EN.MultitecUA.EventoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.EventoEN), recuerdo.EventoRecordado.Id);

                        recuerdo.EventoRecordado.RecuerdosEvento
                        .Add (recuerdo);
                }

                session.Save (recuerdo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recuerdo.Id;
}

public void Modify (RecuerdoEN recuerdo)
{
        try
        {
                SessionInitializeTransaction ();
                RecuerdoEN recuerdoEN = (RecuerdoEN)session.Load (typeof(RecuerdoEN), recuerdo.Id);

                recuerdoEN.Titulo = recuerdo.Titulo;


                recuerdoEN.Cuerpo = recuerdo.Cuerpo;


                recuerdoEN.Fotos = recuerdo.Fotos;

                session.Update (recuerdoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
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
                RecuerdoEN recuerdoEN = (RecuerdoEN)session.Load (typeof(RecuerdoEN), id);
                session.Delete (recuerdoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> DameRecuerdosPorProyecto (int p_OID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RecuerdoEN self where select (en) FROM RecuerdoEN en where en.EventoRecordado = :p_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RecuerdoENdameRecuerdosPorProyectoHQL");
                query.SetParameter ("p_OID", p_OID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: RecuerdoEN
public RecuerdoEN ReadOID (int id
                           )
{
        RecuerdoEN recuerdoEN = null;

        try
        {
                SessionInitializeTransaction ();
                recuerdoEN = (RecuerdoEN)session.Get (typeof(RecuerdoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recuerdoEN;
}

public System.Collections.Generic.IList<RecuerdoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RecuerdoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RecuerdoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RecuerdoEN>();
                else
                        result = session.CreateCriteria (typeof(RecuerdoEN)).List<RecuerdoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in RecuerdoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
