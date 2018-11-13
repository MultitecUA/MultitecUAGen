

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
 *      Definition of the class ServicioCEN
 *
 */
public partial class ServicioCEN
{
private IServicioCAD _IServicioCAD;

public ServicioCEN()
{
        this._IServicioCAD = new ServicioCAD ();
}

public ServicioCEN(IServicioCAD _IServicioCAD)
{
        this._IServicioCAD = _IServicioCAD;
}

public IServicioCAD get_IServicioCAD ()
{
        return this._IServicioCAD;
}

public void Destroy (int id
                     )
{
        _IServicioCAD.Destroy (id);
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ServicioEN> DameServiciosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum ? p_estado)
{
        return _IServicioCAD.DameServiciosPorEstado (p_estado);
}
}
}
