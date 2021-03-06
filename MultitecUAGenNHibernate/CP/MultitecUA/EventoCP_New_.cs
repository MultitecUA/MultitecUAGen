
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Evento_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class EventoCP : BasicCP
{
public MultitecUAGenNHibernate.EN.MultitecUA.EventoEN New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fechaInicio, Nullable<DateTime> p_fechaFin, Nullable<DateTime> p_fechaInicioInscripcion, Nullable<DateTime> p_fechaTopeInscripcion, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Evento_new_) ENABLED START*/

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;

        MultitecUAGenNHibernate.EN.MultitecUA.EventoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new  EventoCEN (eventoCAD);




                int oid;
                //Initialized EventoEN
                EventoEN eventoEN;
                eventoEN = new EventoEN ();
                eventoEN.Nombre = p_nombre;

                eventoEN.Descripcion = p_descripcion;

                eventoEN.FechaInicio = p_fechaInicio;

                eventoEN.FechaFin = p_fechaFin;

                eventoEN.FechaInicioInscripcion = p_fechaInicioInscripcion;

                eventoEN.FechaTopeInscripcion = p_fechaTopeInscripcion;

                eventoEN.Fotos = p_fotos;

                //Call to EventoCAD

                oid = eventoCAD.New_ (eventoEN);
                result = eventoCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
