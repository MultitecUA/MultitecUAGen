
using System;
// Definición clase NotificacionEventoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionEventoEN                                                                   : MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN


{
/**
 *	Atributo eventoGenerador
 */
private MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoGenerador;






public virtual MultitecUAGenNHibernate.EN.MultitecUA.EventoEN EventoGenerador {
        get { return eventoGenerador; } set { eventoGenerador = value;  }
}





public NotificacionEventoEN() : base ()
{
}



public NotificacionEventoEN(int id, MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoGenerador
                            , string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha
                            )
{
        this.init (Id, eventoGenerador, titulo, mensaje, notificacionesGeneradas, fecha);
}


public NotificacionEventoEN(NotificacionEventoEN notificacionEvento)
{
        this.init (Id, notificacionEvento.EventoGenerador, notificacionEvento.Titulo, notificacionEvento.Mensaje, notificacionEvento.NotificacionesGeneradas, notificacionEvento.Fecha);
}

private void init (int id
                   , MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoGenerador, string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.EventoGenerador = eventoGenerador;

        this.Titulo = titulo;

        this.Mensaje = mensaje;

        this.NotificacionesGeneradas = notificacionesGeneradas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEventoEN t = obj as NotificacionEventoEN;
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
