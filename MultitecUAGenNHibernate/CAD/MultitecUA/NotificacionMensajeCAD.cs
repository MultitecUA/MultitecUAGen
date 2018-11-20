
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
 * Clase NotificacionMensaje:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NotificacionMensajeCAD : BasicCAD, INotificacionMensajeCAD
{
public NotificacionMensajeCAD() : base ()
{
}

public NotificacionMensajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionMensajeEN ReadOIDDefault (int id
                                             )
{
        NotificacionMensajeEN notificacionMensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionMensajeEN = (NotificacionMensajeEN)session.Get (typeof(NotificacionMensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionMensajeEN;
}

public System.Collections.Generic.IList<NotificacionMensajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionMensajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionMensajeEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionMensajeEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionMensajeEN)).List<NotificacionMensajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionMensajeEN notificacionMensaje)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionMensajeEN notificacionMensajeEN = (NotificacionMensajeEN)session.Load (typeof(NotificacionMensajeEN), notificacionMensaje.Id);

                session.Update (notificacionMensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionMensajeEN notificacionMensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacionMensaje.MensajeGenerador != null) {
                        // Argumento OID y no colección.
                        notificacionMensaje.MensajeGenerador = (MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN), notificacionMensaje.MensajeGenerador.Id);

                        notificacionMensaje.MensajeGenerador.NotificacionGenerada
                        .Add (notificacionMensaje);
                }

                session.Save (notificacionMensaje);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionMensaje.Id;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionMensajeEN notificacionMensajeEN = (NotificacionMensajeEN)session.Load (typeof(NotificacionMensajeEN), id);
                session.Delete (notificacionMensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionMensajeEN
public NotificacionMensajeEN ReadOID (int id
                                      )
{
        NotificacionMensajeEN notificacionMensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionMensajeEN = (NotificacionMensajeEN)session.Get (typeof(NotificacionMensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionMensajeEN;
}

public System.Collections.Generic.IList<NotificacionMensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionMensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionMensajeEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionMensajeEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionMensajeEN)).List<NotificacionMensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionMensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
