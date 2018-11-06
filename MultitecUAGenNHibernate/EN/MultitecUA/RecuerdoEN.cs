
using System;
// Definición clase RecuerdoEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class RecuerdoEN
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
 *	Atributo fotos
 */
private System.Collections.Generic.IList<string> fotos;



/**
 *	Atributo eventoRecordado
 */
private MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoRecordado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual System.Collections.Generic.IList<string> Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.EventoEN EventoRecordado {
        get { return eventoRecordado; } set { eventoRecordado = value;  }
}





public RecuerdoEN()
{
}



public RecuerdoEN(int id, string titulo, string cuerpo, System.Collections.Generic.IList<string> fotos, MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoRecordado
                  )
{
        this.init (Id, titulo, cuerpo, fotos, eventoRecordado);
}


public RecuerdoEN(RecuerdoEN recuerdo)
{
        this.init (Id, recuerdo.Titulo, recuerdo.Cuerpo, recuerdo.Fotos, recuerdo.EventoRecordado);
}

private void init (int id
                   , string titulo, string cuerpo, System.Collections.Generic.IList<string> fotos, MultitecUAGenNHibernate.EN.MultitecUA.EventoEN eventoRecordado)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.Fotos = fotos;

        this.EventoRecordado = eventoRecordado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RecuerdoEN t = obj as RecuerdoEN;
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
