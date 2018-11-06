
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Recuerdo_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class RecuerdoCEN
{
public int New_ (string p_titulo, string p_cuerpo, int p_eventoRecordado, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Recuerdo_new__customized) START*/

        RecuerdoEN recuerdoEN = null;

        int oid;

        //Initialized RecuerdoEN
        recuerdoEN = new RecuerdoEN ();
        recuerdoEN.Titulo = p_titulo;

        recuerdoEN.Cuerpo = p_cuerpo;


        if (p_eventoRecordado != -1) {
                recuerdoEN.EventoRecordado = new MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ();
                recuerdoEN.EventoRecordado.Id = p_eventoRecordado;
        }

        recuerdoEN.Fotos = p_fotos;

        //Call to RecuerdoCAD

        oid = _IRecuerdoCAD.New_ (recuerdoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
