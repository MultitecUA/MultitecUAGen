

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
 *      Definition of the class NoticiaCEN
 *
 */
public partial class NoticiaCEN
{
private INoticiaCAD _INoticiaCAD;

public NoticiaCEN()
{
        this._INoticiaCAD = new NoticiaCAD ();
}

public NoticiaCEN(INoticiaCAD _INoticiaCAD)
{
        this._INoticiaCAD = _INoticiaCAD;
}

public INoticiaCAD get_INoticiaCAD ()
{
        return this._INoticiaCAD;
}

public void Destroy (int id
                     )
{
        _INoticiaCAD.Destroy (id);
}

public NoticiaEN ReadOID (int id
                          )
{
        NoticiaEN noticiaEN = null;

        noticiaEN = _INoticiaCAD.ReadOID (id);
        return noticiaEN;
}

public System.Collections.Generic.IList<NoticiaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NoticiaEN> list = null;

        list = _INoticiaCAD.ReadAll (first, size);
        return list;
}
}
}
