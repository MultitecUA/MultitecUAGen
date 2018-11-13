

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
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionCAD _INotificacionCAD;

public NotificacionCEN()
{
        this._INotificacionCAD = new NotificacionCAD ();
}

public NotificacionCEN(INotificacionCAD _INotificacionCAD)
{
        this._INotificacionCAD = _INotificacionCAD;
}

public INotificacionCAD get_INotificacionCAD ()
{
        return this._INotificacionCAD;
}

public void Destroy (int id
                     )
{
        _INotificacionCAD.Destroy (id);
}
}
}
