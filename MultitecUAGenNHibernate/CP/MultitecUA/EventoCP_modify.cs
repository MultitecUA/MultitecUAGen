
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Evento_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class EventoCP : BasicCP
{
public void Modify (int p_Evento_OID, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, Nullable<DateTime> p_fecha_inscripcion, System.Collections.Generic.IList<string> p_foto)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Evento_modify) ENABLED START*/

        IEventoCAD eventoCAD = null;
        EventoCEN eventoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                eventoCAD = new EventoCAD (session);
                eventoCEN = new  EventoCEN (eventoCAD);




                EventoEN eventoEN = null;
                //Initialized EventoEN
                eventoEN = new EventoEN ();
                eventoEN.Id = p_Evento_OID;
                eventoEN.Nombre = p_nombre;
                eventoEN.Descripcion = p_descripcion;
                eventoEN.Fecha_inicio = p_fecha_inicio;
                eventoEN.Fecha_fin = p_fecha_fin;
                eventoEN.Fecha_inscripcion = p_fecha_inscripcion;
                eventoEN.Foto = p_foto;
                //Call to EventoCAD

                eventoCAD.Modify (eventoEN);


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


        /*PROTECTED REGION END*/
}
}
}
