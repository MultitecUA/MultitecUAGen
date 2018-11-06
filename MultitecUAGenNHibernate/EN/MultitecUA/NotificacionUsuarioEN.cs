
using System;
// Definición clase NotificacionUsuarioEN
namespace MultitecUAGenNHibernate.EN.MultitecUA
{
public partial class NotificacionUsuarioEN
{
/**
 *	Atributo estado
 */
private MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estado;



/**
 *	Atributo usuarioNotificado
 */
private MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioNotificado;



/**
 *	Atributo notificacionGenerada
 */
private MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN notificacionGenerada;



/**
 *	Atributo id
 */
private int id;






public virtual MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN UsuarioNotificado {
        get { return usuarioNotificado; } set { usuarioNotificado = value;  }
}



public virtual MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN NotificacionGenerada {
        get { return notificacionGenerada; } set { notificacionGenerada = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public NotificacionUsuarioEN()
{
}



public NotificacionUsuarioEN(int id, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estado, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioNotificado, MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN notificacionGenerada
                             )
{
        this.init (Id, estado, usuarioNotificado, notificacionGenerada);
}


public NotificacionUsuarioEN(NotificacionUsuarioEN notificacionUsuario)
{
        this.init (Id, notificacionUsuario.Estado, notificacionUsuario.UsuarioNotificado, notificacionUsuario.NotificacionGenerada);
}

private void init (int id
                   , MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum estado, MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN usuarioNotificado, MultitecUAGenNHibernate.EN.MultitecUA.NotificacionEN notificacionGenerada)
{
        this.Id = id;


        this.Estado = estado;

        this.UsuarioNotificado = usuarioNotificado;

        this.NotificacionGenerada = notificacionGenerada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionUsuarioEN t = obj as NotificacionUsuarioEN;
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
