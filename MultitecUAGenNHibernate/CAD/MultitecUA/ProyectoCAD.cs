
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
 * Clase Proyecto:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class ProyectoCAD : BasicCAD, IProyectoCAD
{
public ProyectoCAD() : base ()
{
}

public ProyectoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProyectoEN ReadOIDDefault (int id
                                  )
{
        ProyectoEN proyectoEN = null;

        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Get (typeof(ProyectoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proyectoEN;
}

public System.Collections.Generic.IList<ProyectoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProyectoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProyectoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProyectoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProyectoEN)).List<ProyectoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProyectoEN proyecto)
{
        try
        {
                SessionInitializeTransaction ();
                ProyectoEN proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), proyecto.Id);

                proyectoEN.Nombre = proyecto.Nombre;


                proyectoEN.Descripcion = proyecto.Descripcion;


                proyectoEN.Estado = proyecto.Estado;


                proyectoEN.Fotos = proyecto.Fotos;









                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProyectoEN proyecto)
{
        try
        {
                SessionInitializeTransaction ();
                if (proyecto.UsuarioCreador != null) {
                    // Argumento OID y no colección.
                    proyecto.UsuarioCreador = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load(typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), proyecto.UsuarioCreador.Id);

                    proyecto.UsuarioCreador.ProyectosCreados
                    .Add(proyecto);

                    proyecto.UsuarioCreador.ProyectosModerados.Add(proyecto);
                    proyecto.UsuarioCreador.ProyectosPertenecientes.Add(proyecto);

                    proyecto.UsuariosModeradores.Add(proyecto.UsuarioCreador);
                    proyecto.UsuariosParticipantes.Add(proyecto.UsuarioCreador);
                }

                session.Save (proyecto);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proyecto.Id;
}

public void Modify (ProyectoEN proyecto)
{
        try
        {
                SessionInitializeTransaction ();
                ProyectoEN proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), proyecto.Id);

                proyectoEN.Nombre = proyecto.Nombre;


                proyectoEN.Descripcion = proyecto.Descripcion;


                proyectoEN.Fotos = proyecto.Fotos;

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
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
                ProyectoEN proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), id);
                session.Delete (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void CambiarEstado (ProyectoEN proyecto)
{
        try
        {
                SessionInitializeTransaction ();
                ProyectoEN proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), proyecto.Id);

                proyectoEN.Estado = proyecto.Estado;

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AgregaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_Usuarios_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuariosModeradoresENAux = null;
                if (proyectoEN.UsuariosModeradores == null) {
                        proyectoEN.UsuariosModeradores = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                }

                foreach (int item in p_Usuarios_OIDs) {
                        usuariosModeradoresENAux = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                        usuariosModeradoresENAux = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), item);
                        usuariosModeradoresENAux.ProyectosModerados.Add (proyectoEN);

                        proyectoEN.UsuariosModeradores.Add (usuariosModeradoresENAux);
                }


                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AgregaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventosAsociadosENAux = null;
                if (proyectoEN.EventosAsociados == null) {
                        proyectoEN.EventosAsociados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
                }

                foreach (int item in p_eventosAsociados_OIDs) {
                        eventosAsociadosENAux = new MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ();
                        eventosAsociadosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.EventoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.EventoEN), item);
                        eventosAsociadosENAux.ProyectosPresentados.Add (proyectoEN);

                        proyectoEN.EventosAsociados.Add (eventosAsociadosENAux);
                }


                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosUsuarioPertenece (int p_OID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en join en.UsuariosParticipantes usu where usu.Id = :p_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdameProyectosUsuarioPerteneceHQL");
                query.SetParameter ("p_OID", p_OID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEvento (int p_OID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select(en) FROM ProyectoEN en join en.EventosAsociados eve where eve.Id = :p_OID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdameProyectosPorEventoHQL");
                query.SetParameter ("p_OID", p_OID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorCategoria (int p_OID_Categoria)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en join en.CategoriasProyectos cat where cat.Id = :p_OID_Categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdameProyectosPorCategoriaHQL");
                query.SetParameter ("p_OID_Categoria", p_OID_Categoria);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AgregaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN categoriasBuscadasENAux = null;
                if (proyectoEN.CategoriasBuscadas == null) {
                        proyectoEN.CategoriasBuscadas = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN>();
                }

                foreach (int item in p_categoriasBuscadas_OIDs) {
                        categoriasBuscadasENAux = new MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN ();
                        categoriasBuscadasENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN), item);
                        categoriasBuscadasENAux.ProyectosSolicitantes.Add (proyectoEN);

                        proyectoEN.CategoriasBuscadas.Add (categoriasBuscadasENAux);
                }


                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AgregaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN categoriasProyectosENAux = null;
                if (proyectoEN.CategoriasProyectos == null) {
                        proyectoEN.CategoriasProyectos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN>();
                }

                foreach (int item in p_categoriasProyectos_OIDs) {
                        categoriasProyectosENAux = new MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN ();
                        categoriasProyectosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN), item);
                        categoriasProyectosENAux.ProyectosCateogrizados.Add (proyectoEN);

                        proyectoEN.CategoriasProyectos.Add (categoriasProyectosENAux);
                }


                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AgregaParticipantes (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuariosParticipantesENAux = null;
                if (proyectoEN.UsuariosParticipantes == null) {
                        proyectoEN.UsuariosParticipantes = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                }

                foreach (int item in p_usuariosParticipantes_OIDs) {
                        usuariosParticipantesENAux = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                        usuariosParticipantesENAux = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), item);
                        usuariosParticipantesENAux.ProyectosPertenecientes.Add (proyectoEN);

                        proyectoEN.UsuariosParticipantes.Add (usuariosParticipantesENAux);
                }


                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosModeradores_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuariosModeradoresENAux = null;
                if (proyectoEN.UsuariosModeradores != null) {
                        foreach (int item in p_usuariosModeradores_OIDs) {
                                usuariosModeradoresENAux = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), item);
                                if (proyectoEN.UsuariosModeradores.Contains (usuariosModeradoresENAux) == true) {
                                        proyectoEN.UsuariosModeradores.Remove (usuariosModeradoresENAux);
                                        usuariosModeradoresENAux.ProyectosModerados.Remove (proyectoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuariosModeradores_OIDs you are trying to unrelationer, doesn't exist in ProyectoEN");
                        }
                }

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventosAsociadosENAux = null;
                if (proyectoEN.EventosAsociados != null) {
                        foreach (int item in p_eventosAsociados_OIDs) {
                                eventosAsociadosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.EventoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.EventoEN), item);
                                if (proyectoEN.EventosAsociados.Contains (eventosAsociadosENAux) == true) {
                                        proyectoEN.EventosAsociados.Remove (eventosAsociadosENAux);
                                        eventosAsociadosENAux.ProyectosPresentados.Remove (proyectoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_eventosAsociados_OIDs you are trying to unrelationer, doesn't exist in ProyectoEN");
                        }
                }

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN categoriasBuscadasENAux = null;
                if (proyectoEN.CategoriasBuscadas != null) {
                        foreach (int item in p_categoriasBuscadas_OIDs) {
                                categoriasBuscadasENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN), item);
                                if (proyectoEN.CategoriasBuscadas.Contains (categoriasBuscadasENAux) == true) {
                                        proyectoEN.CategoriasBuscadas.Remove (categoriasBuscadasENAux);
                                        categoriasBuscadasENAux.ProyectosSolicitantes.Remove (proyectoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_categoriasBuscadas_OIDs you are trying to unrelationer, doesn't exist in ProyectoEN");
                        }
                }

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN categoriasProyectosENAux = null;
                if (proyectoEN.CategoriasProyectos != null) {
                        foreach (int item in p_categoriasProyectos_OIDs) {
                                categoriasProyectosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN), item);
                                if (proyectoEN.CategoriasProyectos.Contains (categoriasProyectosENAux) == true) {
                                        proyectoEN.CategoriasProyectos.Remove (categoriasProyectosENAux);
                                        categoriasProyectosENAux.ProyectosCateogrizados.Remove (proyectoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_categoriasProyectos_OIDs you are trying to unrelationer, doesn't exist in ProyectoEN");
                        }
                }

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminaParticipantes (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoEN = null;
                proyectoEN = (ProyectoEN)session.Load (typeof(ProyectoEN), p_Proyecto_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuariosParticipantesENAux = null;
                if (proyectoEN.UsuariosParticipantes != null) {
                        foreach (int item in p_usuariosParticipantes_OIDs) {
                                usuariosParticipantesENAux = (MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN), item);
                                if (proyectoEN.UsuariosParticipantes.Contains (usuariosParticipantesENAux) == true) {
                                        proyectoEN.UsuariosParticipantes.Remove (usuariosParticipantesENAux);
                                        usuariosParticipantesENAux.ProyectosPertenecientes.Remove (proyectoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuariosParticipantes_OIDs you are trying to unrelationer, doesn't exist in ProyectoEN");
                        }
                }

                session.Update (proyectoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum ? p_estado)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en where en.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdameProyectosPorEstadoHQL");
                query.SetParameter ("p_estado", p_estado);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: ProyectoEN
public ProyectoEN ReadOID (int id
                           )
{
        ProyectoEN proyectoEN = null;

        try
        {
                SessionInitializeTransaction ();
                proyectoEN = (ProyectoEN)session.Get (typeof(ProyectoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return proyectoEN;
}

public System.Collections.Generic.IList<ProyectoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProyectoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProyectoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProyectoEN>();
                else
                        result = session.CreateCriteria (typeof(ProyectoEN)).List<ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ReadNombre (string p_nombre)
{
        MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en where en.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENreadNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);


                result = query.UniqueResult<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en where en.Nombre like :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdameProyectosPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DamePoyectosPorCategoriaUsuario (int p_OID_Categoria)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProyectoEN self where select (en) FROM ProyectoEN en join en.CategoriasBuscadas cat where cat.Id = :p_OID_Categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProyectoENdamePoyectosPorCategoriaUsuarioHQL");
                query.SetParameter ("p_OID_Categoria", p_OID_Categoria);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in ProyectoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
