
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
 * Clase Servicio:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class ServicioCAD : BasicCAD, IServicioCAD
{
public ServicioCAD() : base ()
{
}

public ServicioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ServicioEN ReadOIDDefault (int id
                                  )
{
        ServicioEN servicioEN = null;

        try
        {
                SessionInitializeTransaction ();
                servicioEN = (ServicioEN)session.Get (typeof(ServicioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return servicioEN;
}

public System.Collections.Generic.IList<ServicioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ServicioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ServicioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ServicioEN>();
                        else
                                result = session.CreateCriteria (typeof(ServicioEN)).List<ServicioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ServicioEN servicio)
{
        try
        {
                SessionInitializeTransaction ();
                ServicioEN servicioEN = (ServicioEN)session.Load (typeof(ServicioEN), servicio.Id);

                servicioEN.Nombre = servicio.Nombre;


                servicioEN.Descripcion = servicio.Descripcion;


                servicioEN.Estado = servicio.Estado;


                servicioEN.FotosServicio = servicio.FotosServicio;

                session.Update (servicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ServicioEN servicio)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (servicio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return servicio.Id;
}

public void Modify (ServicioEN servicio)
{
        try
        {
                SessionInitializeTransaction ();
                ServicioEN servicioEN = (ServicioEN)session.Load (typeof(ServicioEN), servicio.Id);

                servicioEN.Nombre = servicio.Nombre;


                servicioEN.Descripcion = servicio.Descripcion;


                servicioEN.Estado = servicio.Estado;


                servicioEN.FotosServicio = servicio.FotosServicio;

                session.Update (servicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
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
                ServicioEN servicioEN = (ServicioEN)session.Load (typeof(ServicioEN), id);
                session.Delete (servicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void CambiarDisponibilidad (ServicioEN servicio)
{
        try
        {
                SessionInitializeTransaction ();
                ServicioEN servicioEN = (ServicioEN)session.Load (typeof(ServicioEN), servicio.Id);

                servicioEN.Estado = servicio.Estado;

                session.Update (servicioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ServicioEN> DameServiciosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum ? p_estado)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ServicioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ServicioEN self where select (en) FROM ServicioEN en where en.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ServicioENdameServiciosPorEstadoHQL");
                query.SetParameter ("p_estado", p_estado);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ServicioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: ServicioEN
public ServicioEN ReadOID (int id
                           )
{
        ServicioEN servicioEN = null;

        try
        {
                SessionInitializeTransaction ();
                servicioEN = (ServicioEN)session.Get (typeof(ServicioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return servicioEN;
}

public System.Collections.Generic.IList<ServicioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ServicioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ServicioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ServicioEN>();
                else
                        result = session.CreateCriteria (typeof(ServicioEN)).List<ServicioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ServicioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
