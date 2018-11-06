

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
 *      Definition of the class NotificacionSolicitudCEN
 *
 */
public partial class NotificacionSolicitudCEN
{
private INotificacionSolicitudCAD _INotificacionSolicitudCAD;

public NotificacionSolicitudCEN()
{
        this._INotificacionSolicitudCAD = new NotificacionSolicitudCAD ();
}

public NotificacionSolicitudCEN(INotificacionSolicitudCAD _INotificacionSolicitudCAD)
{
        this._INotificacionSolicitudCAD = _INotificacionSolicitudCAD;
}

public INotificacionSolicitudCAD get_INotificacionSolicitudCAD ()
{
        return this._INotificacionSolicitudCAD;
}

public NotificacionSolicitudEN ReadOID (int id
                                        )
{
        NotificacionSolicitudEN notificacionSolicitudEN = null;

        notificacionSolicitudEN = _INotificacionSolicitudCAD.ReadOID (id);
        return notificacionSolicitudEN;
}

public System.Collections.Generic.IList<NotificacionSolicitudEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionSolicitudEN> list = null;

        list = _INotificacionSolicitudCAD.ReadAll (first, size);
        return list;
}
public void Destroy (int id
                     )
{
        _INotificacionSolicitudCAD.Destroy (id);
}
}
}
