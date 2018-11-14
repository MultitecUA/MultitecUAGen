

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
 *      Definition of the class EventoCEN
 *
 */
public partial class EventoCEN
{
private IEventoCAD _IEventoCAD;

public EventoCEN()
{
        this._IEventoCAD = new EventoCAD ();
}

public EventoCEN(IEventoCAD _IEventoCAD)
{
        this._IEventoCAD = _IEventoCAD;
}

public IEventoCAD get_IEventoCAD ()
{
        return this._IEventoCAD;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorProyecto (int p_OID)
{
        return _IEventoCAD.DameEventosPorProyecto (p_OID);
}
public void AgregaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs)
{
        //Call to EventoCAD

        _IEventoCAD.AgregaCategorias (p_Evento_OID, p_categoriasEventos_OIDs);
}
public void EliminaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs)
{
        //Call to EventoCAD

        _IEventoCAD.EliminaCategorias (p_Evento_OID, p_categoriasEventos_OIDs);
}
}
}
