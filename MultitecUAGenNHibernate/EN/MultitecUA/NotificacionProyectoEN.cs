
using System;
// Definición clase NotificacionProyectoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionProyectoEN                                                                 : MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN


{
/**
 *	Atributo proyectoGenerador
 */
private MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoGenerador;






public virtual MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ProyectoGenerador {
        get { return proyectoGenerador; } set { proyectoGenerador = value;  }
}





public NotificacionProyectoEN() : base ()
{
}



public NotificacionProyectoEN(int id, MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoGenerador
                              , string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha
                              )
{
        this.init (Id, proyectoGenerador, titulo, mensaje, notificacionesGeneradas, fecha);
}


public NotificacionProyectoEN(NotificacionProyectoEN notificacionProyecto)
{
        this.init (Id, notificacionProyecto.ProyectoGenerador, notificacionProyecto.Titulo, notificacionProyecto.Mensaje, notificacionProyecto.NotificacionesGeneradas, notificacionProyecto.Fecha);
}

private void init (int id
                   , MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN proyectoGenerador, string titulo, string mensaje, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> notificacionesGeneradas, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.ProyectoGenerador = proyectoGenerador;

        this.Titulo = titulo;

        this.Mensaje = mensaje;

        this.NotificacionesGeneradas = notificacionesGeneradas;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionProyectoEN t = obj as NotificacionProyectoEN;
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
