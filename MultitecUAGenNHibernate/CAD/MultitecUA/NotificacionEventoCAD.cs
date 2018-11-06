
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
 * Clase NotificacionEvento:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NotificacionEventoCAD : BasicCAD, INotificacionEventoCAD
{
public NotificacionEventoCAD() : base ()
{
}

public NotificacionEventoCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionEventoEN ReadOIDDefault (int id
                                            )
{
        NotificacionEventoEN notificacionEventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEventoEN = (NotificacionEventoEN)session.Get (typeof(NotificacionEventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEventoEN;
}

public System.Collections.Generic.IList<NotificacionEventoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEventoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionEventoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEventoEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionEventoEN)).List<NotificacionEventoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEventoEN notificacionEvento)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEventoEN notificacionEventoEN = (NotificacionEventoEN)session.Load (typeof(NotificacionEventoEN), notificacionEvento.Id);

                session.Update (notificacionEventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEventoEN notificacionEvento)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacionEvento.EventoGenerador != null) {
                        // Argumento OID y no colección.
                        notificacionEvento.EventoGenerador = (MultitecUAGenNHibernate.EN.MultitecUA.EventoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.EventoEN), notificacionEvento.EventoGenerador.Id);

                        notificacionEvento.EventoGenerador.NotificacionGenerada
                        .Add (notificacionEvento);
                }

                session.Save (notificacionEvento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEvento.Id;
}

//Sin e: ReadOID
//Con e: NotificacionEventoEN
public NotificacionEventoEN ReadOID (int id
                                     )
{
        NotificacionEventoEN notificacionEventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEventoEN = (NotificacionEventoEN)session.Get (typeof(NotificacionEventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEventoEN;
}

public System.Collections.Generic.IList<NotificacionEventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEventoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionEventoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEventoEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionEventoEN)).List<NotificacionEventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEventoEN notificacionEventoEN = (NotificacionEventoEN)session.Load (typeof(NotificacionEventoEN), id);
                session.Delete (notificacionEventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionEventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
