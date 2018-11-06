
using System;
// Definición clase ProyectoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class ProyectoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo estado
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum estado;



/**
 *	Atributo fotos
 */
private System.Collections.Generic.IList<string> fotos;



/**
 *	Atributo usuarioCreador
 */
private MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioCreador;



/**
 *	Atributo usuariosParticipantes
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosParticipantes;



/**
 *	Atributo usuariosModeradores
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosModeradores;



/**
 *	Atributo eventosAsociados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosAsociados;



/**
 *	Atributo categoriasProyectos
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasProyectos;



/**
 *	Atributo categoriasBuscadas
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasBuscadas;



/**
 *	Atributo solicitudRecibida
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudRecibida;



/**
 *	Atributo notificacionGenerada
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionProyectoEN> notificacionGenerada;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<string> Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN UsuarioCreador {
        get { return usuarioCreador; } set { usuarioCreador = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> UsuariosParticipantes {
        get { return usuariosParticipantes; } set { usuariosParticipantes = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> UsuariosModeradores {
        get { return usuariosModeradores; } set { usuariosModeradores = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> EventosAsociados {
        get { return eventosAsociados; } set { eventosAsociados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> CategoriasProyectos {
        get { return categoriasProyectos; } set { categoriasProyectos = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> CategoriasBuscadas {
        get { return categoriasBuscadas; } set { categoriasBuscadas = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> SolicitudRecibida {
        get { return solicitudRecibida; } set { solicitudRecibida = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionProyectoEN> NotificacionGenerada {
        get { return notificacionGenerada; } set { notificacionGenerada = value;  }
}





public ProyectoEN()
{
        usuariosParticipantes = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
        usuariosModeradores = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
        eventosAsociados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
        categoriasProyectos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN>();
        categoriasBuscadas = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN>();
        solicitudRecibida = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN>();
        notificacionGenerada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionProyectoEN>();
}



public ProyectoEN(int id, string nombre, string descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum estado, System.Collections.Generic.IList<string> fotos, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioCreador, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosParticipantes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosModeradores, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosAsociados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasProyectos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasBuscadas, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudRecibida, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionProyectoEN> notificacionGenerada
                  )
{
        this.init (Id, nombre, descripcion, estado, fotos, usuarioCreador, usuariosParticipantes, usuariosModeradores, eventosAsociados, categoriasProyectos, categoriasBuscadas, solicitudRecibida, notificacionGenerada);
}


public ProyectoEN(ProyectoEN proyecto)
{
        this.init (Id, proyecto.Nombre, proyecto.Descripcion, proyecto.Estado, proyecto.Fotos, proyecto.UsuarioCreador, proyecto.UsuariosParticipantes, proyecto.UsuariosModeradores, proyecto.EventosAsociados, proyecto.CategoriasProyectos, proyecto.CategoriasBuscadas, proyecto.SolicitudRecibida, proyecto.NotificacionGenerada);
}

private void init (int id
                   , string nombre, string descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum estado, System.Collections.Generic.IList<string> fotos, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioCreador, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosParticipantes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosModeradores, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosAsociados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasProyectos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasBuscadas, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudRecibida, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionProyectoEN> notificacionGenerada)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Estado = estado;

        this.Fotos = fotos;

        this.UsuarioCreador = usuarioCreador;

        this.UsuariosParticipantes = usuariosParticipantes;

        this.UsuariosModeradores = usuariosModeradores;

        this.EventosAsociados = eventosAsociados;

        this.CategoriasProyectos = categoriasProyectos;

        this.CategoriasBuscadas = categoriasBuscadas;

        this.SolicitudRecibida = solicitudRecibida;

        this.NotificacionGenerada = notificacionGenerada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProyectoEN t = obj as ProyectoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
