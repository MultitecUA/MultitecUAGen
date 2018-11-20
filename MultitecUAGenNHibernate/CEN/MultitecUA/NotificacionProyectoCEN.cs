

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
 *      Definition of the class NotificacionProyectoCEN
 *
 */
public partial class NotificacionProyectoCEN
{
private INotificacionProyectoCAD _INotificacionProyectoCAD;

public NotificacionProyectoCEN()
{
        this._INotificacionProyectoCAD = new NotificacionProyectoCAD ();
}

public NotificacionProyectoCEN(INotificacionProyectoCAD _INotificacionProyectoCAD)
{
        this._INotificacionProyectoCAD = _INotificacionProyectoCAD;
}

public INotificacionProyectoCAD get_INotificacionProyectoCAD ()
{
        return this._INotificacionProyectoCAD;
}

public void Destroy (int id
                     )
{
        _INotificacionProyectoCAD.Destroy (id);
}

public NotificacionProyectoEN ReadOID (int id
                                       )
{
        NotificacionProyectoEN notificacionProyectoEN = null;

        notificacionProyectoEN = _INotificacionProyectoCAD.ReadOID (id);
        return notificacionProyectoEN;
}

public System.Collections.Generic.IList<NotificacionProyectoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionProyectoEN> list = null;

        list = _INotificacionProyectoCAD.ReadAll (first, size);
        return list;
}
}
}
