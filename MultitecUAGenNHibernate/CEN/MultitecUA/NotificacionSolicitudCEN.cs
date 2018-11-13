

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

public void Destroy (int id
                     )
{
        _INotificacionSolicitudCAD.Destroy (id);
}
}
}
