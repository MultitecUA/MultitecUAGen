
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
 *	Atributo fotoNoticia
 */
private string fotoNoticia;



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



public virtual string FotoNoticia {
        get { return fotoNoticia; } set { fotoNoticia = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public NoticiaEN()
{
}



public NoticiaEN(int id, string titulo, string cuerpo, string fotoNoticia, Nullable<DateTime> fecha
                 )
{
        this.init (Id, titulo, cuerpo, fotoNoticia, fecha);
}


public NoticiaEN(NoticiaEN noticia)
{
        this.init (Id, noticia.Titulo, noticia.Cuerpo, noticia.FotoNoticia, noticia.Fecha);
}

private void init (int id
                   , string titulo, string cuerpo, string fotoNoticia, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.FotoNoticia = fotoNoticia;

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
