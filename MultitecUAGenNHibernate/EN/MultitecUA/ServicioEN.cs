
using System;
// Definición clase ServicioEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class ServicioEN
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
 *	Atributo estado
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum estado;



/**
 *	Atributo fotosServicio
 */
private System.Collections.Generic.IList<string> fotosServicio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<string> FotosServicio {
        get { return fotosServicio; } set { fotosServicio = value;  }
}





public ServicioEN()
{
}



public ServicioEN(int id, string nombre, string descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum estado, System.Collections.Generic.IList<string> fotosServicio
                  )
{
        this.init (Id, nombre, descripcion, estado, fotosServicio);
}


public ServicioEN(ServicioEN servicio)
{
        this.init (Id, servicio.Nombre, servicio.Descripcion, servicio.Estado, servicio.FotosServicio);
}

private void init (int id
                   , string nombre, string descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum estado, System.Collections.Generic.IList<string> fotosServicio)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Estado = estado;

        this.FotosServicio = fotosServicio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ServicioEN t = obj as ServicioEN;
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
