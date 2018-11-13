

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
 *      Definition of the class NotificacionMensajeCEN
 *
 */
public partial class NotificacionMensajeCEN
{
private INotificacionMensajeCAD _INotificacionMensajeCAD;

public NotificacionMensajeCEN()
{
        this._INotificacionMensajeCAD = new NotificacionMensajeCAD ();
}

public NotificacionMensajeCEN(INotificacionMensajeCAD _INotificacionMensajeCAD)
{
        this._INotificacionMensajeCAD = _INotificacionMensajeCAD;
}

public INotificacionMensajeCAD get_INotificacionMensajeCAD ()
{
        return this._INotificacionMensajeCAD;
}

public void Destroy (int id
                     )
{
        _INotificacionMensajeCAD.Destroy (id);
}
}
}
