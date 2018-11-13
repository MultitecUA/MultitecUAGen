

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;

using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
/*
 *      Definition of the class NotificacionUsuarioCEN
 *
 */
public partial class NotificacionUsuarioCEN
{
private INotificacionUsuarioCAD _INotificacionUsuarioCAD;

public NotificacionUsuarioCEN()
{
        this._INotificacionUsuarioCAD = new NotificacionUsuarioCAD ();
}

public NotificacionUsuarioCEN(INotificacionUsuarioCAD _INotificacionUsuarioCAD)
{
        this._INotificacionUsuarioCAD = _INotificacionUsuarioCAD;
}

public INotificacionUsuarioCAD get_INotificacionUsuarioCAD ()
{
        return this._INotificacionUsuarioCAD;
}

public void Destroy (int id
                     )
{
        _INotificacionUsuarioCAD.Destroy (id);
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameNotificacionesPorUsuario (int p_oid_usuario)
{
        return _INotificacionUsuarioCAD.DameNotificacionesPorUsuario (p_oid_usuario);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameNotificacionesNoLeidasPorUsuario (int p_oid_usuario)
{
        return _INotificacionUsuarioCAD.DameNotificacionesNoLeidasPorUsuario (p_oid_usuario);
}
}
}
