
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
 * Clase NotificacionSolicitud:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NotificacionSolicitudCAD : BasicCAD, INotificacionSolicitudCAD
{
public NotificacionSolicitudCAD() : base ()
{
}

public NotificacionSolicitudCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionSolicitudEN ReadOIDDefault (int id
                                               )
{
        NotificacionSolicitudEN notificacionSolicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionSolicitudEN = (NotificacionSolicitudEN)session.Get (typeof(NotificacionSolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionSolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionSolicitudEN;
}

public System.Collections.Generic.IList<NotificacionSolicitudEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionSolicitudEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionSolicitudEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionSolicitudEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionSolicitudEN)).List<NotificacionSolicitudEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionSolicitudCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionSolicitudEN notificacionSolicitud)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionSolicitudEN notificacionSolicitudEN = (NotificacionSolicitudEN)session.Load (typeof(NotificacionSolicitudEN), notificacionSolicitud.Id);

                session.Update (notificacionSolicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionSolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionSolicitudEN notificacionSolicitud)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacionSolicitud.SolicitudGeneradora != null) {
                        // Argumento OID y no colección.
                        notificacionSolicitud.SolicitudGeneradora = (MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN), notificacionSolicitud.SolicitudGeneradora.Id);

                        notificacionSolicitud.SolicitudGeneradora.NotificacionGenerada
                        .Add (notificacionSolicitud);
                }

                session.Save (notificacionSolicitud);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionSolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionSolicitud.Id;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionSolicitudEN notificacionSolicitudEN = (NotificacionSolicitudEN)session.Load (typeof(NotificacionSolicitudEN), id);
                session.Delete (notificacionSolicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionSolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
