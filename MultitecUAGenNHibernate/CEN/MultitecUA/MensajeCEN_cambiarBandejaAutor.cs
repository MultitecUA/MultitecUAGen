
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarBandejaAutor) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public void CambiarBandejaAutor (int p_Mensaje_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum p_bandejaAutor)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarBandejaAutor_customized) START*/

        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.BandejaAutor = p_bandejaAutor;
        //Call to MensajeCAD

        _IMensajeCAD.CambiarBandejaAutor (mensajeEN);

        /*PROTECTED REGION END*/
}
}
}
