
using System;
// Definición clase MensajeEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class MensajeEN
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
 *	Atributo usuarioAutor
 */
private MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioAutor;



/**
 *	Atributo usuarioReceptor
 */
private MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioReceptor;



/**
 *	Atributo archivosAdjuntos
 */
private System.Collections.Generic.IList<string> archivosAdjuntos;



/**
 *	Atributo estadoLecutra
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estadoLecutra;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo notificacionGenerada
 */
private System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionMensajeEN> notificacionGenerada;



/**
 *	Atributo bandejaAutor
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaAutor;



/**
 *	Atributo bandejaReceptor
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaReceptor;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Cuerpo {
        get { return cuerpo; } set { cuerpo = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN UsuarioAutor {
        get { return usuarioAutor; } set { usuarioAutor = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN UsuarioReceptor {
        get { return usuarioReceptor; } set { usuarioReceptor = value;  }
}



public virtual System.Collections.Generic.IList<string> ArchivosAdjuntos {
        get { return archivosAdjuntos; } set { archivosAdjuntos = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum EstadoLecutra {
        get { return estadoLecutra; } set { estadoLecutra = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionMensajeEN> NotificacionGenerada {
        get { return notificacionGenerada; } set { notificacionGenerada = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum BandejaAutor {
        get { return bandejaAutor; } set { bandejaAutor = value;  }
}



public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum BandejaReceptor {
        get { return bandejaReceptor; } set { bandejaReceptor = value;  }
}





public MensajeEN()
{
        notificacionGenerada = new System.Collections.Generic.List<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionMensajeEN>();
}



public MensajeEN(int id, string titulo, string cuerpo, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioAutor, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioReceptor, System.Collections.Generic.IList<string> archivosAdjuntos, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estadoLecutra, Nullable<DateTime> fecha, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionMensajeEN> notificacionGenerada, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaAutor, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaReceptor
                 )
{
        this.init (Id, titulo, cuerpo, usuarioAutor, usuarioReceptor, archivosAdjuntos, estadoLecutra, fecha, notificacionGenerada, bandejaAutor, bandejaReceptor);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (Id, mensaje.Titulo, mensaje.Cuerpo, mensaje.UsuarioAutor, mensaje.UsuarioReceptor, mensaje.ArchivosAdjuntos, mensaje.EstadoLecutra, mensaje.Fecha, mensaje.NotificacionGenerada, mensaje.BandejaAutor, mensaje.BandejaReceptor);
}

private void init (int id
                   , string titulo, string cuerpo, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioAutor, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioReceptor, System.Collections.Generic.IList<string> archivosAdjuntos, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estadoLecutra, Nullable<DateTime> fecha, System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionMensajeEN> notificacionGenerada, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaAutor, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum bandejaReceptor)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Cuerpo = cuerpo;

        this.UsuarioAutor = usuarioAutor;

        this.UsuarioReceptor = usuarioReceptor;

        this.ArchivosAdjuntos = archivosAdjuntos;

        this.EstadoLecutra = estadoLecutra;

        this.Fecha = fecha;

        this.NotificacionGenerada = notificacionGenerada;

        this.BandejaAutor = bandejaAutor;

        this.BandejaReceptor = bandejaReceptor;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
