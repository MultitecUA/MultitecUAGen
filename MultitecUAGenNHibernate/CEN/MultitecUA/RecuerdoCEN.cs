

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
 *      Definition of the class RecuerdoCEN
 *
 */
public partial class RecuerdoCEN
{
private IRecuerdoCAD _IRecuerdoCAD;

public RecuerdoCEN()
{
        this._IRecuerdoCAD = new RecuerdoCAD ();
}

public RecuerdoCEN(IRecuerdoCAD _IRecuerdoCAD)
{
        this._IRecuerdoCAD = _IRecuerdoCAD;
}

public IRecuerdoCAD get_IRecuerdoCAD ()
{
        return this._IRecuerdoCAD;
}

public void Destroy (int id
                     )
{
        _IRecuerdoCAD.Destroy (id);
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> DameRecuerdos (int p_OID)
{
        return _IRecuerdoCAD.DameRecuerdos (p_OID);
}
public RecuerdoEN ReadOID (int id
                           )
{
        RecuerdoEN recuerdoEN = null;

        recuerdoEN = _IRecuerdoCAD.ReadOID (id);
        return recuerdoEN;
}

public System.Collections.Generic.IList<RecuerdoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RecuerdoEN> list = null;

        list = _IRecuerdoCAD.ReadAll (first, size);
        return list;
}
}
}
