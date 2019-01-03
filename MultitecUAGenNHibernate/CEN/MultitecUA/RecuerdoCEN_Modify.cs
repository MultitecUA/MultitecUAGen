
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Recuerdo_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class RecuerdoCEN
{
public void Modify (int p_Recuerdo_OID, string p_titulo, string p_cuerpo, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Recuerdo_modify_customized) START*/

        RecuerdoEN recuerdoEN = null;

        //Initialized RecuerdoEN
        recuerdoEN = new RecuerdoEN ();
        recuerdoEN.Id = p_Recuerdo_OID;
        recuerdoEN.Titulo = p_titulo;
        recuerdoEN.Cuerpo = p_cuerpo;
        recuerdoEN.FotosRecuerdo = p_fotos;
        //Call to RecuerdoCAD

        _IRecuerdoCAD.Modify (recuerdoEN);

        /*PROTECTED REGION END*/
}
}
}
