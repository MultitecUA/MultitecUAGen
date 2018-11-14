
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Servicio_cambiarDisponibilidad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class ServicioCEN
{
public void CambiarDisponibilidad (int p_Servicio_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum p_estado)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Servicio_cambiarDisponibilidad_customized) START*/

        ServicioEN servicioEN = null;

        //Initialized ServicioEN
        servicioEN = new ServicioEN ();
        servicioEN.Id = p_Servicio_OID;
        servicioEN.Estado = p_estado;
        //Call to ServicioCAD

        _IServicioCAD.CambiarDisponibilidad (servicioEN);

        /*PROTECTED REGION END*/
}
}
}
