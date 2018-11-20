

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
public MensajeEN ReadOID (int id
                          )
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (id);
        return mensajeEN;
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
}
}
