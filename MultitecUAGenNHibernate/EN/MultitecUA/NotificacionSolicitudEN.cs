
using System;
// Definición clase NotificacionSolicitudEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionSolicitudEN                                                                        : MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN


{
/**
 *	Atributo solicitudGeneradora
 */
private MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN solicitudGeneradora;






public virtual MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN SolicitudGeneradora {
        get { return solicitudGeneradora; } set { solicitudGeneradora = value;  }
}





public NotificacionSolicitudEN() : base ()
{
}



public NotificacionSolicitudEN(int id, MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN solicitudGeneradora
                               , string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha
                               )
{
        this.init (Id, solicitudGeneradora, titulo, mensaje, notificacionesGeneradas, fecha);
}


public NotificacionSolicitudEN(NotificacionSolicitudEN notificacionSolicitud)
{
        this.init (Id, notificacionSolicitud.SolicitudGeneradora, notificacionSolicitud.Titulo, notificacionSolicitud.Mensaje, notificacionSolicitud.NotificacionesGeneradas, notificacionSolicitud.Fecha);
}

private void init (int id
                   , MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN solicitudGeneradora, string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.SolicitudGeneradora = solicitudGeneradora;

        this.Titulo = titulo;

        this.Mensaje = mensaje;

        this.NotificacionesGeneradas = notificacionesGeneradas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionSolicitudEN t = obj as NotificacionSolicitudEN;
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
