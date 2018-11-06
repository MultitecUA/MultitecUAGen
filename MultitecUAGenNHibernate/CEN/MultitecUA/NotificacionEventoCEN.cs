

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
 *      Definition of the class NotificacionEventoCEN
 *
 */
public partial class NotificacionEventoCEN
{
private INotificacionEventoCAD _INotificacionEventoCAD;

public NotificacionEventoCEN()
{
        this._INotificacionEventoCAD = new NotificacionEventoCAD ();
}

public NotificacionEventoCEN(INotificacionEventoCAD _INotificacionEventoCAD)
{
        this._INotificacionEventoCAD = _INotificacionEventoCAD;
}

public INotificacionEventoCAD get_INotificacionEventoCAD ()
{
        return this._INotificacionEventoCAD;
}

public NotificacionEventoEN ReadOID (int id
                                     )
{
        NotificacionEventoEN notificacionEventoEN = null;

        notificacionEventoEN = _INotificacionEventoCAD.ReadOID (id);
        return notificacionEventoEN;
}

public System.Collections.Generic.IList<NotificacionEventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEventoEN> list = null;

        list = _INotificacionEventoCAD.ReadAll (first, size);
        return list;
}
public void Destroy (int id
                     )
{
        _INotificacionEventoCAD.Destroy (id);
}
}
}
