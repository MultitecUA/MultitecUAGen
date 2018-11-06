
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
 * Clase Solicitud:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class SolicitudCAD : BasicCAD, ISolicitudCAD
{
public SolicitudCAD() : base ()
{
}

public SolicitudCAD(ISession sessionAux) : base (sessionAux)
{
}



public SolicitudEN ReadOIDDefault (int id
                                   )
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SolicitudEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<SolicitudEN>();
                        else
                                result = session.CreateCriteria (typeof(SolicitudEN)).List<SolicitudEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                SolicitudEN solicitudEN = (SolicitudEN)session.Load (typeof(SolicitudEN), solicitud.Id);

                solicitudEN.Fecha = solicitud.Fecha;





                solicitudEN.Estado = solicitud.Estado;

                session.Update (solicitudEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (SolicitudEN solicitud)
{
        try
        {
                SessionInitializeTransaction ();
                if (solicitud.UsuarioSolicitante != null) {
                        // Argumento OID y no colección.
                        solicitud.UsuarioSolicitante = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), solicitud.UsuarioSolicitante.Id);

                        solicitud.UsuarioSolicitante.SolicitudCreada
                        .Add (solicitud);
                }
                if (solicitud.ProyectoSolicitado != null) {
                        // Argumento OID y no colección.
                        solicitud.ProyectoSolicitado = (MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN), solicitud.ProyectoSolicitado.Id);

                        solicitud.ProyectoSolicitado.SolicitudRecibida
                        .Add (solicitud);
                }

                session.Save (solicitud);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitud.Id;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPendientes (int p_OIDProyecto)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN en where en.ProyectoSolicitado.Id = :p_OIDProyecto and en.Estado = 1";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdameSolicitudesPendientesHQL");
                query.SetParameter ("p_OIDProyecto", p_OIDProyecto);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameMisSolicitudes (int p_OID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN en where en.UsuarioSolicitante.Id = :p_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdameMisSolicitudesHQL");
                query.SetParameter ("p_OID", p_OID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: SolicitudEN
public SolicitudEN ReadOID (int id
                            )
{
        SolicitudEN solicitudEN = null;

        try
        {
                SessionInitializeTransaction ();
                solicitudEN = (SolicitudEN)session.Get (typeof(SolicitudEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SolicitudEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SolicitudEN>();
                else
                        result = session.CreateCriteria (typeof(SolicitudEN)).List<SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesRechazadas (int p_OIDProyecto)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SolicitudEN self where FROM SolicitudEN en where en.ProyectoSolicitado.Id = :p_OIDProyecto and en.Estado = 3";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SolicitudENdameSolicitudesRechazadasHQL");
                query.SetParameter ("p_OIDProyecto", p_OIDProyecto);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in SolicitudCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
