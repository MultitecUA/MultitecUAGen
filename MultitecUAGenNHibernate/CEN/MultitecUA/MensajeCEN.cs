

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
 *      Definition of the class MensajeCEN
 *
 */
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public void Destroy (int id
                     )
{
        _IMensajeCAD.Destroy (id);
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptor (int p_oid_usuario)
{
        return _IMensajeCAD.DameMensajesPorReceptor (p_oid_usuario);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutor (int p_oid_usuario)
{
        return _IMensajeCAD.DameMensajesPorAutor (p_oid_usuario);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorNoLeidos (int p_oid_usuario)
{
        return _IMensajeCAD.DameMensajesPorReceptorNoLeidos (p_oid_usuario);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorPosterioresA (Nullable<DateTime> p_fecha)
{
        return _IMensajeCAD.DameMensajesPorAutorPosterioresA (p_fecha);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorAnterioresA (Nullable<DateTime> p_fecha)
{
        return _IMensajeCAD.DameMensajesPorAutorAnterioresA (p_fecha);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorPosterioresA (Nullable<DateTime> p_fecha)
{
        return _IMensajeCAD.DameMensajesPorReceptorPosterioresA (p_fecha);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorAnterioresA (Nullable<DateTime> p_fecha)
{
        return _IMensajeCAD.DameMensajesPorReceptorAnterioresA (p_fecha);
}
}
}
