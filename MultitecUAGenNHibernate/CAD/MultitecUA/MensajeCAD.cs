
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
 * Clase Mensaje:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class MensajeCAD : BasicCAD, IMensajeCAD
{
public MensajeCAD() : base ()
{
}

public MensajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public MensajeEN ReadOIDDefault (int id
                                 )
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MensajeEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(MensajeEN)).List<MensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), mensaje.Id);

                mensajeEN.Titulo = mensaje.Titulo;


                mensajeEN.Cuerpo = mensaje.Cuerpo;




                mensajeEN.ArchivosAdjuntos = mensaje.ArchivosAdjuntos;


                mensajeEN.Estado = mensaje.Estado;


                mensajeEN.Fecha = mensaje.Fecha;


                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (mensaje.UsuarioAutor != null) {
                        // Argumento OID y no colección.
                        mensaje.UsuarioAutor = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), mensaje.UsuarioAutor.Id);

                        mensaje.UsuarioAutor.MensajesEnviados
                        .Add (mensaje);
                }
                if (mensaje.UsuarioReceptor != null) {
                        // Argumento OID y no colección.
                        mensaje.UsuarioReceptor = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), mensaje.UsuarioReceptor.Id);

                        mensaje.UsuarioReceptor.MensajesRecibidos
                        .Add (mensaje);
                }

                session.Save (mensaje);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensaje.Id;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), id);
                session.Delete (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptor (int p_oid_usuario)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioReceptor.Id = :p_oid_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorReceptorHQL");
                query.SetParameter ("p_oid_usuario", p_oid_usuario);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutor (int p_oid_usuario)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioAutor.Id = :p_oid_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorAutorHQL");
                query.SetParameter ("p_oid_usuario", p_oid_usuario);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorNoLeidos (int p_oid_usuario)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioReceptor.Id = :p_oid_usuario and en.Estado = 2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorReceptorNoLeidosHQL");
                query.SetParameter ("p_oid_usuario", p_oid_usuario);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorPosterioresA (Nullable<DateTime> p_fecha)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioAutor.Id = :p_oid_usuario and en.Fecha > :p_fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorAutorPosterioresAHQL");
                query.SetParameter ("p_fecha", p_fecha);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorAnterioresA (Nullable<DateTime> p_fecha)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioAutor.Id = :p_oid_usuario and en.Fecha < :p_fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorAutorAnterioresAHQL");
                query.SetParameter ("p_fecha", p_fecha);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorPosterioresA (Nullable<DateTime> p_fecha)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioReceptor.Id = :p_oid_usuario and en.Fecha > :p_fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorReceptorPosterioresAHQL");
                query.SetParameter ("p_fecha", p_fecha);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorAnterioresA (Nullable<DateTime> p_fecha)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where FROM MensajeEN en where en.UsuarioReceptor.Id = :p_oid_usuario and en.Fecha < :p_fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENdameMensajesPorReceptorAnterioresAHQL");
                query.SetParameter ("p_fecha", p_fecha);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
