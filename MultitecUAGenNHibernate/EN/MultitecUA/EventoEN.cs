
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
 *	Atributo foto
 */
private System.Collections.Generic.IList<string> foto;



/**
 *	Atributo fecha_inicio
 */
private Nullable<DateTime> fecha_inicio;



/**
 *	Atributo fecha_fin
 */
private Nullable<DateTime> fecha_fin;



/**
 *	Atributo fecha_inscripcion
 */
private Nullable<DateTime> fecha_inscripcion;



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






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<string> Foto {
        get { return foto; } set { foto = value;  }
}



public virtual Nullable<DateTime> Fecha_inicio {
        get { return fecha_inicio; } set { fecha_inicio = value;  }
}



public virtual Nullable<DateTime> Fecha_fin {
        get { return fecha_fin; } set { fecha_fin = value;  }
}



public virtual Nullable<DateTime> Fecha_inscripcion {
        get { return fecha_inscripcion; } set { fecha_inscripcion = value;  }
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





public EventoEN()
{
        proyectosPresentados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        recuerdosEvento = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN>();
        categoriasEventos = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN>();
        notificacionGenerada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN>();
}



public EventoEN(int id, string nombre, string descripcion, System.Collections.Generic.IList<string> foto, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, Nullable<DateTime> fecha_inscripcion, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPresentados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> recuerdosEvento, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasEventos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> notificacionGenerada
                )
{
        this.init (Id, nombre, descripcion, foto, fecha_inicio, fecha_fin, fecha_inscripcion, proyectosPresentados, recuerdosEvento, categoriasEventos, notificacionGenerada);
}


public EventoEN(EventoEN evento)
{
        this.init (Id, evento.Nombre, evento.Descripcion, evento.Foto, evento.Fecha_inicio, evento.Fecha_fin, evento.Fecha_inscripcion, evento.ProyectosPresentados, evento.RecuerdosEvento, evento.CategoriasEventos, evento.NotificacionGenerada);
}

private void init (int id
                   , string nombre, string descripcion, System.Collections.Generic.IList<string> foto, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, Nullable<DateTime> fecha_inscripcion, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosPresentados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> recuerdosEvento, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN> categoriasEventos, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEventoEN> notificacionGenerada)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Foto = foto;

        this.Fecha_inicio = fecha_inicio;

        this.Fecha_fin = fecha_fin;

        this.Fecha_inscripcion = fecha_inscripcion;

        this.ProyectosPresentados = proyectosPresentados;

        this.RecuerdosEvento = recuerdosEvento;

        this.CategoriasEventos = categoriasEventos;

        this.NotificacionGenerada = notificacionGenerada;
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
