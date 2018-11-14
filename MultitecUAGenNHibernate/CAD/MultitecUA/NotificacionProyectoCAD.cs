
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
 * Clase NotificacionProyecto:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class NotificacionProyectoCAD : BasicCAD, INotificacionProyectoCAD
{
public NotificacionProyectoCAD() : base ()
{
}

public NotificacionProyectoCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionProyectoEN ReadOIDDefault (int id
                                              )
{
        NotificacionProyectoEN notificacionProyectoEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionProyectoEN = (NotificacionProyectoEN)session.Get (typeof(NotificacionProyectoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionProyectoEN;
}

public System.Collections.Generic.IList<NotificacionProyectoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionProyectoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionProyectoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionProyectoEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionProyectoEN)).List<NotificacionProyectoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionProyectoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionProyectoEN notificacionProyecto)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionProyectoEN notificacionProyectoEN = (NotificacionProyectoEN)session.Load (typeof(NotificacionProyectoEN), notificacionProyecto.Id);

                session.Update (notificacionProyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionProyectoEN notificacionProyecto)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacionProyecto.ProyectoGenerador != null) {
                        // Argumento OID y no colección.
                        notificacionProyecto.ProyectoGenerador = (MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN), notificacionProyecto.ProyectoGenerador.Id);

                        notificacionProyecto.ProyectoGenerador.NotificacionGenerada
                        .Add (notificacionProyecto);
                }

                session.Save (notificacionProyecto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionProyecto.Id;
}

public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionProyectoEN notificacionProyectoEN = (NotificacionProyectoEN)session.Load (typeof(NotificacionProyectoEN), id);
                session.Delete (notificacionProyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
