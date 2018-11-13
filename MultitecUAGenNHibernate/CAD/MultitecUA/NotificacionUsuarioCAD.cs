
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
 * Clase NotificacionUsuario:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NotificacionUsuarioCAD : BasicCAD, INotificacionUsuarioCAD
{
public NotificacionUsuarioCAD() : base ()
{
}

public NotificacionUsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionUsuarioEN ReadOIDDefault (int id
                                             )
{
        NotificacionUsuarioEN notificacionUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionUsuarioEN = (NotificacionUsuarioEN)session.Get (typeof(NotificacionUsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionUsuarioEN;
}

public System.Collections.Generic.IList<NotificacionUsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionUsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionUsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionUsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionUsuarioEN)).List<NotificacionUsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionUsuarioEN notificacionUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionUsuarioEN notificacionUsuarioEN = (NotificacionUsuarioEN)session.Load (typeof(NotificacionUsuarioEN), notificacionUsuario.Id);

                notificacionUsuarioEN.Estado = notificacionUsuario.Estado;



                session.Update (notificacionUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionUsuarioEN notificacionUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacionUsuario.UsuarioNotificado != null) {
                        // Argumento OID y no colección.
                        notificacionUsuario.UsuarioNotificado = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), notificacionUsuario.UsuarioNotificado.Id);

                        notificacionUsuario.UsuarioNotificado.DestinatariosNotificados
                        .Add (notificacionUsuario);
                }
                if (notificacionUsuario.NotificacionGenerada != null) {
                        // Argumento OID y no colección.
                        notificacionUsuario.NotificacionGenerada = (MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN), notificacionUsuario.NotificacionGenerada.Id);

                        notificacionUsuario.NotificacionGenerada.NotificacionesGeneradas
                        .Add (notificacionUsuario);
                }

                session.Save (notificacionUsuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionUsuario.Id;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionUsuarioEN notificacionUsuarioEN = (NotificacionUsuarioEN)session.Load (typeof(NotificacionUsuarioEN), id);
                session.Delete (notificacionUsuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameNotificacionesPorUsuario (int p_oid_usuario)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionUsuarioEN self where select (en) FROM NotificacionUsuarioEN en join en.UsuarioNotificado usu where usu.Id = :p_oid_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionUsuarioENdameNotificacionesPorUsuarioHQL");
                query.SetParameter ("p_oid_usuario", p_oid_usuario);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameNotificacionesNoLeidasPorUsuario (int p_oid_usuario)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionUsuarioEN self where select (en) FROM NotificacionUsuarioEN en join en.UsuarioNotificado usu where usu.Id = :p_oid_usuario and en.Estado = 2";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionUsuarioENdameNotificacionesNoLeidasPorUsuarioHQL");
                query.SetParameter ("p_oid_usuario", p_oid_usuario);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionUsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
