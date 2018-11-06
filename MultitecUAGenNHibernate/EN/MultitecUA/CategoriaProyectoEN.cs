
using System;
// Definición clase CategoriaProyectoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class CategoriaProyectoEN
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
 *	Atributo proyectosCateogrizados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCateogrizados;



/**
 *	Atributo eventosCategorizados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosCategorizados;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosCateogrizados {
        get { return proyectosCateogrizados; } set { proyectosCateogrizados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> EventosCategorizados {
        get { return eventosCategorizados; } set { eventosCategorizados = value;  }
}





public CategoriaProyectoEN()
{
        proyectosCateogrizados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
        eventosCategorizados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN>();
}



public CategoriaProyectoEN(int id, string nombre, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCateogrizados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosCategorizados
                           )
{
        this.init (Id, nombre, proyectosCateogrizados, eventosCategorizados);
}


public CategoriaProyectoEN(CategoriaProyectoEN categoriaProyecto)
{
        this.init (Id, categoriaProyecto.Nombre, categoriaProyecto.ProyectosCateogrizados, categoriaProyecto.EventosCategorizados);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosCateogrizados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> eventosCategorizados)
{
        this.Id = id;


        this.Nombre = nombre;

        this.ProyectosCateogrizados = proyectosCateogrizados;

        this.EventosCategorizados = eventosCategorizados;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaProyectoEN t = obj as CategoriaProyectoEN;
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
