
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarBandejaReceptor) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public void CambiarBandejaReceptor (int p_Mensaje_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum p_bandejaReceptor)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarBandejaReceptor_customized) START*/

        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.BandejaReceptor = p_bandejaReceptor;
        //Call to MensajeCAD

        _IMensajeCAD.CambiarBandejaReceptor (mensajeEN);

        /*PROTECTED REGION END*/
}
}
}
