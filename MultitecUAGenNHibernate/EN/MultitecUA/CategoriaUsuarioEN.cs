
using System;
// Definición clase CategoriaUsuarioEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class CategoriaUsuarioEN
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
 *	Atributo usuariosCategorizados
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosCategorizados;



/**
 *	Atributo proyectosSolicitantes
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosSolicitantes;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> UsuariosCategorizados {
        get { return usuariosCategorizados; } set { usuariosCategorizados = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> ProyectosSolicitantes {
        get { return proyectosSolicitantes; } set { proyectosSolicitantes = value;  }
}





public CategoriaUsuarioEN()
{
        usuariosCategorizados = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN>();
        proyectosSolicitantes = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN>();
}



public CategoriaUsuarioEN(int id, string nombre, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosCategorizados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosSolicitantes
                          )
{
        this.init (Id, nombre, usuariosCategorizados, proyectosSolicitantes);
}


public CategoriaUsuarioEN(CategoriaUsuarioEN categoriaUsuario)
{
        this.init (Id, categoriaUsuario.Nombre, categoriaUsuario.UsuariosCategorizados, categoriaUsuario.ProyectosSolicitantes);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> usuariosCategorizados, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> proyectosSolicitantes)
{
        this.Id = id;


        this.Nombre = nombre;

        this.UsuariosCategorizados = usuariosCategorizados;

        this.ProyectosSolicitantes = proyectosSolicitantes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaUsuarioEN t = obj as CategoriaUsuarioEN;
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
