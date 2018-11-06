
using System;
// Definición clase NotificacionEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo notificacionesGeneradas
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> NotificacionesGeneradas {
        get { return notificacionesGeneradas; } set { notificacionesGeneradas = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public NotificacionEN()
{
        notificacionesGeneradas = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN>();
}



public NotificacionEN(int id, string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha
                      )
{
        this.init (Id, titulo, mensaje, notificacionesGeneradas, fecha);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Titulo, notificacion.Mensaje, notificacion.NotificacionesGeneradas, notificacion.Fecha);
}

private void init (int id
                   , string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Mensaje = mensaje;

        this.NotificacionesGeneradas = notificacionesGeneradas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
