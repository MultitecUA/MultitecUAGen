
using System;
// Definición clase EventoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class EventoEN
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
 *	Atributo fotos
 */
private System.Collections.Generic.IList<string> fotos;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo fechaInicioInscripcion
 */
private Nullable<DateTime> fechaInicioInscripcion;



/**
 *	Atributo proyectosPresentados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPresentados;



/**
 *	Atributo recuerdosEvento
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> recuerdosEvento;



/**
 *	Atributo categoriasEventos
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasEventos;



/**
 *	Atributo notificacionGenerada
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> notificacionGenerada;



/**
 *	Atributo fechaTopeInscripcion
 */
private Nullable<DateTime> fechaTopeInscripcion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<string> Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual Nullable<DateTime> FechaInicioInscripcion {
        get { return fechaInicioInscripcion; } set { fechaInicioInscripcion = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosPresentados {
        get { return proyectosPresentados; } set { proyectosPresentados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> RecuerdosEvento {
        get { return recuerdosEvento; } set { recuerdosEvento = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> CategoriasEventos {
        get { return categoriasEventos; } set { categoriasEventos = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> NotificacionGenerada {
        get { return notificacionGenerada; } set { notificacionGenerada = value;  }
}



public virtual Nullable<DateTime> FechaTopeInscripcion {
        get { return fechaTopeInscripcion; } set { fechaTopeInscripcion = value;  }
}





public EventoEN()
{
        proyectosPresentados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        recuerdosEvento = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN>();
        categoriasEventos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN>();
        notificacionGenerada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN>();
}



public EventoEN(int id, string nombre, string descripcion, System.Collections.Generic.IList<string> fotos, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Nullable<DateTime> fechaInicioInscripcion, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPresentados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> recuerdosEvento, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasEventos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> notificacionGenerada, Nullable<DateTime> fechaTopeInscripcion
                )
{
        this.init (Id, nombre, descripcion, fotos, fechaInicio, fechaFin, fechaInicioInscripcion, proyectosPresentados, recuerdosEvento, categoriasEventos, notificacionGenerada, fechaTopeInscripcion);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Nombre, evento.Descripcion, evento.Fotos, evento.FechaInicio, evento.FechaFin, evento.FechaInicioInscripcion, evento.ProyectosPresentados, evento.RecuerdosEvento, evento.CategoriasEventos, evento.NotificacionGenerada, evento.FechaTopeInscripcion);
}

private void init (int id
                   , string nombre, string descripcion, System.Collections.Generic.IList<string> fotos, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin, Nullable<DateTime> fechaInicioInscripcion, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPresentados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> recuerdosEvento, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasEventos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> notificacionGenerada, Nullable<DateTime> fechaTopeInscripcion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Fotos = fotos;

        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;

        this.FechaInicioInscripcion = fechaInicioInscripcion;

        this.ProyectosPresentados = proyectosPresentados;

        this.RecuerdosEvento = recuerdosEvento;

        this.CategoriasEventos = categoriasEventos;

        this.NotificacionGenerada = notificacionGenerada;

        this.FechaTopeInscripcion = fechaTopeInscripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EventoEN t = obj as EventoEN;
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
