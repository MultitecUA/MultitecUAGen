
using System;
// Definición clase AdministradorEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class AdministradorEN                                                                        : MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(int id,
                       string nombre, String password, string foto, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCreados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPertenecientes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosModerados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> destinatariosNotificados, string email, Nullable<DateTime> fechaAlta, string nick, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasUsuarios, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudCreada
                       )
{
        this.init (Id, nombre, password, foto, proyectosCreados, proyectosPertenecientes, proyectosModerados, mensajesEnviados, mensajesRecibidos, destinatariosNotificados, email, fechaAlta, nick, categoriasUsuarios, solicitudCreada);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Id, administrador.Nombre, administrador.Password, administrador.Foto, administrador.ProyectosCreados, administrador.ProyectosPertenecientes, administrador.ProyectosModerados, administrador.MensajesEnviados, administrador.MensajesRecibidos, administrador.DestinatariosNotificados, administrador.Email, administrador.FechaAlta, administrador.Nick, administrador.CategoriasUsuarios, administrador.SolicitudCreada);
}

private void init (int id
                   , string nombre, String password, string foto, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCreados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPertenecientes, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosModerados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesEnviados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> mensajesRecibidos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> destinatariosNotificados, string email, Nullable<DateTime> fechaAlta, string nick, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaUsuarioEN> categoriasUsuarios, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> solicitudCreada)
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
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
