
using System;
// Definición clase NoticiaEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NoticiaEN
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
 *	Atributo cuerpo
 */
private string cuerpo;



/**
 *	Atributo foto
 */
private string foto;



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



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public NoticiaEN()
{
}



public NoticiaEN(int id, string titulo, string cuerpo, string foto, Nullable<DateTime> fecha
                 )
{
        this.init (Id, titulo, cuerpo, foto, fecha);
}


public NoticiaEN(NoticiaEN noticia)
{
        this.init (Id, noticia.Titulo, noticia.Cuerpo, noticia.Foto, noticia.Fecha);
}

private void init (int id
                   , string titulo, string cuerpo, string foto, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.Foto = foto;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NoticiaEN t = obj as NoticiaEN;
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
