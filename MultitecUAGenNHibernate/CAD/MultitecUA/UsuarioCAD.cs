
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
 * Clase Usuario:
 *
 */

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Password = usuario.Password;


                usuarioEN.Foto = usuario.Foto;








                usuarioEN.Email = usuario.Email;


                usuarioEN.FechaAlta = usuario.FechaAlta;


                usuarioEN.Nick = usuario.Nick;




                usuarioEN.Rol = usuario.Rol;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Password = usuario.Password;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Foto = usuario.Foto;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosCandidatosAProyecto (System.Collections.Generic.IList<int> p_OIDCategoria, int p_OIDProyecto)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select (en) FROM UsuarioEN en join en.ProyectosPertenecientes pro join en.CategoriasUsuarios cat where cat.Id = :p_OIDCategoria and pro.Id != :p_OIDProyecto";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosCandidatosAProyectoHQL");
                query.SetParameter ("p_OIDCategoria", p_OIDCategoria);
                query.SetParameter ("p_OIDProyecto", p_OIDProyecto);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameModeradoresProyecto (int p_ID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select (en) FROM UsuarioEN en join en.ProyectosModerados pro where pro.Id = :p_ID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameModeradoresProyectoHQL");
                query.SetParameter ("p_ID", p_ID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameParticipantesProyecto (int p_ID)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select (en) FROM UsuarioEN en join en.ProyectosPertenecientes pro where pro.Id = :p_ID";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameParticipantesProyectoHQL");
                query.SetParameter ("p_ID", p_ID);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AgregaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs)
{
        MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN categoriasUsuariosENAux = null;
                if (usuarioEN.CategoriasUsuarios == null) {
                        usuarioEN.CategoriasUsuarios = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN>();
                }

                foreach (int item in p_categoriasUsuarios_OIDs) {
                        categoriasUsuariosENAux = new MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN ();
                        categoriasUsuariosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN), item);
                        categoriasUsuariosENAux.UsuariosCategorizados.Add (usuarioEN);

                        usuarioEN.CategoriasUsuarios.Add (categoriasUsuariosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN categoriasUsuariosENAux = null;
                if (usuarioEN.CategoriasUsuarios != null) {
                        foreach (int item in p_categoriasUsuarios_OIDs) {
                                categoriasUsuariosENAux = (MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN)session.Load (typeof(MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN), item);
                                if (usuarioEN.CategoriasUsuarios.Contains (categoriasUsuariosENAux) == true) {
                                        usuarioEN.CategoriasUsuarios.Remove (categoriasUsuariosENAux);
                                        categoriasUsuariosENAux.UsuariosCategorizados.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_categoriasUsuarios_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosPorCategoria (int p_categoria)
{
        System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where select (en) FROM UsuarioEN en join en.CategoriasUsuarios cat where cat = :p_categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENdameUsuariosPorCategoriaHQL");
                query.SetParameter ("p_categoria", p_categoria);

                result = query.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void CambiarRol (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Rol = usuario.Rol;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is MultitecUAGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new MultitecUAGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
