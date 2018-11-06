
using System;
// Definición clase SolicitudEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class SolicitudEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo usuarioSolicitante
 */
private MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioSolicitante;



/**
 *	Atributo proyectoSolicitado
 */
private MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoSolicitado;



/**
 *	Atributo notificacionGenerada
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionSolicitudEN> notificacionGenerada;



/**
 *	Atributo estado
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum estado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN UsuarioSolicitante {
        get { return usuarioSolicitante; } set { usuarioSolicitante = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ProyectoSolicitado {
        get { return proyectoSolicitado; } set { proyectoSolicitado = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionSolicitudEN> NotificacionGenerada {
        get { return notificacionGenerada; } set { notificacionGenerada = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum Estado {
        get { return estado; } set { estado = value;  }
}





public SolicitudEN()
{
        notificacionGenerada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionSolicitudEN>();
}



public SolicitudEN(int id, Nullable<DateTime> fecha, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioSolicitante, MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoSolicitado, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionSolicitudEN> notificacionGenerada, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum estado
                   )
{
        this.init (Id, fecha, usuarioSolicitante, proyectoSolicitado, notificacionGenerada, estado);
}


public SolicitudEN(SolicitudEN solicitud)
{
        this.init (Id, solicitud.Fecha, solicitud.UsuarioSolicitante, solicitud.ProyectoSolicitado, solicitud.NotificacionGenerada, solicitud.Estado);
}

private void init (int id
                   , Nullable<DateTime> fecha, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioSolicitante, MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoSolicitado, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionSolicitudEN> notificacionGenerada, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum estado)
{
        this.Id = id;


        this.Fecha = fecha;

        this.UsuarioSolicitante = usuarioSolicitante;

        this.ProyectoSolicitado = proyectoSolicitado;

        this.NotificacionGenerada = notificacionGenerada;

        this.Estado = estado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SolicitudEN t = obj as SolicitudEN;
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
