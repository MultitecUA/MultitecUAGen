

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
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Evento_agregaCategorias) ENABLED START*/
            /*EventoCEN eventoCEN = new EventoCEN();
            IList<CategoriaProyectoEN> lista = eventoCEN.ReadOID(p_Evento_OID).CategoriasEventos;

            
            foreach (CategoriaProyectoEN categoria in lista)
            {
                if (p_categoriasEventos_OIDs.Contains(categoria.Id))
                {
                    p_categoriasEventos_OIDs.Remove(categoria.Id);
                }
            }*/

            /*PROTECTED REGION END*/
            //Call to EventoCAD

            _IEventoCAD.AgregaCategorias (p_Evento_OID, p_categoriasEventos_OIDs);
}
public void EliminaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs)
{
        //Call to EventoCAD

        _IEventoCAD.EliminaCategorias (p_Evento_OID, p_categoriasEventos_OIDs);
}
public EventoEN ReadOID (int id
                         )
{
        EventoEN eventoEN = null;

        eventoEN = _IEventoCAD.ReadOID (id);
        return eventoEN;
}

public System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EventoEN> list = null;

        list = _IEventoCAD.ReadAll (first, size);
        return list;
}
public void EliminaProyectosAsociados (int p_Evento_OID, System.Collections.Generic.IList<int> p_proyectosPresentados_OIDs)
{
        //Call to EventoCAD

        _IEventoCAD.EliminaProyectosAsociados (p_Evento_OID, p_proyectosPresentados_OIDs);
}
public MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ReadNombre (string p_nombre)
{
        return _IEventoCAD.ReadNombre (p_nombre);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorNombre (string p_nombre)
{
        return _IEventoCAD.DameEventosPorNombre (p_nombre);
}
}
}
