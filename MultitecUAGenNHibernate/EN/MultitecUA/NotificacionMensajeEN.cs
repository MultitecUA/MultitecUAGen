
using System;
// Definición clase NotificacionMensajeEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionMensajeEN                                                                  : MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN


{
/**
 *	Atributo mensajeGenerador
 */
private MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN mensajeGenerador;






public virtual MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN MensajeGenerador {
        get { return mensajeGenerador; } set { mensajeGenerador = value;  }
}





public NotificacionMensajeEN() : base ()
{
}



public NotificacionMensajeEN(int id, MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN mensajeGenerador
                             , string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha
                             )
{
        this.init (Id, mensajeGenerador, titulo, mensaje, notificacionesGeneradas, fecha);
}


public NotificacionMensajeEN(NotificacionMensajeEN notificacionMensaje)
{
        this.init (Id, notificacionMensaje.MensajeGenerador, notificacionMensaje.Titulo, notificacionMensaje.Mensaje, notificacionMensaje.NotificacionesGeneradas, notificacionMensaje.Fecha);
}

private void init (int id
                   , MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN mensajeGenerador, string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.MensajeGenerador = mensajeGenerador;

        this.Titulo = titulo;

        this.Mensaje = mensaje;

        this.NotificacionesGeneradas = notificacionesGeneradas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionMensajeEN t = obj as NotificacionMensajeEN;
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
