
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public void CambiarEstado (int p_Mensaje_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum p_estadoLecutra)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_cambiarEstado_customized) START*/

        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_Mensaje_OID;
        mensajeEN.EstadoLecutra = p_estadoLecutra;
        //Call to MensajeCAD

        _IMensajeCAD.CambiarEstado (mensajeEN);

        /*PROTECTED REGION END*/
}
}
}
