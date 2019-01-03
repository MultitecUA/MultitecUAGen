
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Evento_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class EventoCEN
{
public int New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, Nullable<DateTime> p_fechaInicioInscripcion, Nullable<DateTime> p_fechaTopeInscripcion, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Evento_new__customized) START*/

        EventoEN eventoEN = null;

        int oid;

        //Initialized EventoEN
        eventoEN = new EventoEN ();
        eventoEN.Nombre = p_nombre;

        eventoEN.Descripcion = p_descripcion;

        eventoEN.FechaInicio = p_fechaInicio;

        eventoEN.FechaFin = p_fechaFin;

        eventoEN.FechaInicioInscripcion = p_fechaInicioInscripcion;

        eventoEN.FechaTopeInscripcion = p_fechaTopeInscripcion;

        eventoEN.FotosEvento = p_fotos;

        //Call to EventoCAD

        oid = _IEventoCAD.New_ (eventoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
