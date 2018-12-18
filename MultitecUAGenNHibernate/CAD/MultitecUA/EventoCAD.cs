
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
 * Clase Evento:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class EventoCAD : BasicCAD, IEventoCAD
{
public EventoCAD() : base ()
{
}

public EventoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventoEN ReadOIDDefault (int id
                                )
{
        EventoEN eventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Get (typeof(EventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoEN;
}

public System.Collections.Generic.IList<EventoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EventoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EventoEN>();
                        else
                                result = session.CreateCriteria (typeof(EventoEN)).List<EventoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EventoEN evento)
{
        try
        {
                SessionInitializeTransaction ();
                EventoEN eventoEN = (EventoEN)session.Load (typeof(EventoEN), evento.Id);

                eventoEN.Nombre = evento.Nombre;


                eventoEN.Descripcion = evento.Descripcion;


                eventoEN.Fotos = evento.Fotos;


                eventoEN.FechaInicio = evento.FechaInicio;


                eventoEN.FechaFin = evento.FechaFin;


                eventoEN.FechaInicioInscripcion = evento.FechaInicioInscripcion;






                eventoEN.FechaTopeInscripcion = evento.FechaTopeInscripcion;

                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (EventoEN evento)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (evento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evento.Id;
}

public void Modify (EventoEN evento)
{
        try
        {
                SessionInitializeTransaction ();
                EventoEN eventoEN = (EventoEN)session.Load (typeof(EventoEN), evento.Id);

                eventoEN.Nombre = evento.Nombre;


                eventoEN.Descripcion = evento.Descripcion;


                eventoEN.FechaInicio = evento.FechaInicio;


                eventoEN.FechaFin = evento.FechaFin;


                eventoEN.FechaInicioInscripcion = evento.FechaInicioInscripcion;


                eventoEN.FechaTopeInscripcion = evento.FechaTopeInscripcion;


                eventoEN.Fotos = evento.Fotos;

                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
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
                EventoEN eventoEN = (EventoEN)session.Load (typeof(EventoEN), id);
                session.Delete (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorProyecto (int p_OID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where select(en) FROM EventoEN en join en.ProyectosPresentados pro where pro.Id = :p_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENdameEventosPorProyectoHQL");
                query.SetParameter ("p_OID", p_OID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosFiltrados (int p_categoria, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where select (en) FROM EventoEN en join en.CategoriasEventos cat where cat.Id = :p_categoria and en.FechaInicio < :p_fecha_anterior and en.FechaInicio > :p_fecha_posterior";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENdameEventosFiltradosHQL");
                query.SetParameter ("p_categoria", p_categoria);
                query.SetParameter ("p_fecha_anterior", p_fecha_anterior);
                query.SetParameter ("p_fecha_posterior", p_fecha_posterior);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AgregaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoEN = null;
        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Load (typeof(EventoEN), p_Evento_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN categoriasEventosENAux = null;
                if (eventoEN.CategoriasEventos == null) {
                        eventoEN.CategoriasEventos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN>();
                }

                foreach (int item in p_categoriasEventos_OIDs) {
                        categoriasEventosENAux = new MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN ();
                        categoriasEventosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN), item);
                        categoriasEventosENAux.EventosCategorizados.Add (eventoEN);

                        eventoEN.CategoriasEventos.Add (categoriasEventosENAux);
                }


                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoEN = null;
                eventoEN = (EventoEN)session.Load (typeof(EventoEN), p_Evento_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN categoriasEventosENAux = null;
                if (eventoEN.CategoriasEventos != null) {
                        foreach (int item in p_categoriasEventos_OIDs) {
                                categoriasEventosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN), item);
                                if (eventoEN.CategoriasEventos.Contains (categoriasEventosENAux) == true) {
                                        eventoEN.CategoriasEventos.Remove (categoriasEventosENAux);
                                        categoriasEventosENAux.EventosCategorizados.Remove (eventoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_categoriasEventos_OIDs you are trying to unrelationer, doesn't exist in EventoEN");
                        }
                }

                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: EventoEN
public EventoEN ReadOID (int id
                         )
{
        EventoEN eventoEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventoEN = (EventoEN)session.Get (typeof(EventoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventoEN;
}

public System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EventoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EventoEN>();
                else
                        result = session.CreateCriteria (typeof(EventoEN)).List<EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void EliminaProyectosAsociados (int p_Evento_OID, System.Collections.Generic.IList<int> p_proyectosPresentados_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoEN = null;
                eventoEN = (EventoEN)session.Load (typeof(EventoEN), p_Evento_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectosPresentadosENAux = null;
                if (eventoEN.ProyectosPresentados != null) {
                        foreach (int item in p_proyectosPresentados_OIDs) {
                                proyectosPresentadosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN), item);
                                if (eventoEN.ProyectosPresentados.Contains (proyectosPresentadosENAux) == true) {
                                        eventoEN.ProyectosPresentados.Remove (proyectosPresentadosENAux);
                                        proyectosPresentadosENAux.EventosAsociados.Remove (eventoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_proyectosPresentados_OIDs you are trying to unrelationer, doesn't exist in EventoEN");
                        }
                }

                session.Update (eventoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ReadNombre (string p_nombre)
{
        MultitecUAGenNHibernate.EN.MultitecUA.EventoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where select (en) FROM EventoEN en where en.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENreadNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventoEN self where select (en) FROM EventoEN en where en.Nombre like :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventoENdameEventosPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in EventoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
