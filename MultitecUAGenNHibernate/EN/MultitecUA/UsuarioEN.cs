
using System;
// Definición clase UsuarioEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class UsuarioEN
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
 *	Atributo password
 */
private String password;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo proyectosCreados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCreados;



/**
 *	Atributo proyectosPertenecientes
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPertenecientes;



/**
 *	Atributo proyectosModerados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosModerados;



/**
 *	Atributo mensajesEnviados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesEnviados;



/**
 *	Atributo mensajesRecibidos
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesRecibidos;



/**
 *	Atributo destinatariosNotificados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> destinatariosNotificados;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo fechaAlta
 */
private Nullable<DateTime> fechaAlta;



/**
 *	Atributo nick
 */
private string nick;



/**
 *	Atributo categoriasUsuarios
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasUsuarios;



/**
 *	Atributo solicitudCreada
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudCreada;



/**
 *	Atributo rol
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum rol;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosCreados {
        get { return proyectosCreados; } set { proyectosCreados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosPertenecientes {
        get { return proyectosPertenecientes; } set { proyectosPertenecientes = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosModerados {
        get { return proyectosModerados; } set { proyectosModerados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> MensajesEnviados {
        get { return mensajesEnviados; } set { mensajesEnviados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> MensajesRecibidos {
        get { return mensajesRecibidos; } set { mensajesRecibidos = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DestinatariosNotificados {
        get { return destinatariosNotificados; } set { destinatariosNotificados = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual Nullable<DateTime> FechaAlta {
        get { return fechaAlta; } set { fechaAlta = value;  }
}



public virtual string Nick {
        get { return nick; } set { nick = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> CategoriasUsuarios {
        get { return categoriasUsuarios; } set { categoriasUsuarios = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> SolicitudCreada {
        get { return solicitudCreada; } set { solicitudCreada = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum Rol {
        get { return rol; } set { rol = value;  }
}





public UsuarioEN()
{
        proyectosCreados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        proyectosPertenecientes = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        proyectosModerados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        mensajesEnviados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
        mensajesRecibidos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN>();
        destinatariosNotificados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN>();
        categoriasUsuarios = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN>();
        solicitudCreada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN>();
}



public UsuarioEN(int id, string nombre, String password, string foto, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCreados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPertenecientes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosModerados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> destinatariosNotificados, string email, Nullable<DateTime> fechaAlta, string nick, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasUsuarios, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudCreada, MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum rol
                 )
{
        this.init (Id, nombre, password, foto, proyectosCreados, proyectosPertenecientes, proyectosModerados, mensajesEnviados, mensajesRecibidos, destinatariosNotificados, email, fechaAlta, nick, categoriasUsuarios, solicitudCreada, rol);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Nombre, usuario.Password, usuario.Foto, usuario.ProyectosCreados, usuario.ProyectosPertenecientes, usuario.ProyectosModerados, usuario.MensajesEnviados, usuario.MensajesRecibidos, usuario.DestinatariosNotificados, usuario.Email, usuario.FechaAlta, usuario.Nick, usuario.CategoriasUsuarios, usuario.SolicitudCreada, usuario.Rol);
}

private void init (int id
                   , string nombre, String password, string foto, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCreados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPertenecientes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosModerados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> destinatariosNotificados, string email, Nullable<DateTime> fechaAlta, string nick, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasUsuarios, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudCreada, MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum rol)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Password = password;

        this.Foto = foto;

        this.ProyectosCreados = proyectosCreados;

        this.ProyectosPertenecientes = proyectosPertenecientes;

        this.ProyectosModerados = proyectosModerados;

        this.MensajesEnviados = mensajesEnviados;

        this.MensajesRecibidos = mensajesRecibidos;

        this.DestinatariosNotificados = destinatariosNotificados;

        this.Email = email;

        this.FechaAlta = fechaAlta;

        this.Nick = nick;

        this.CategoriasUsuarios = categoriasUsuarios;

        this.SolicitudCreada = solicitudCreada;

        this.Rol = rol;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
