
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Servicio_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class ServicioCEN
{
public void Modify (int p_Servicio_OID, string p_nombre, string p_descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum p_estado, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Servicio_modify_customized) START*/

        ServicioEN servicioEN = null;

        //Initialized ServicioEN
        servicioEN = new ServicioEN ();
        servicioEN.Id = p_Servicio_OID;
        servicioEN.Nombre = p_nombre;
        servicioEN.Descripcion = p_descripcion;
        servicioEN.Estado = p_estado;
        servicioEN.FotosServicio = p_fotos;
        //Call to ServicioCAD

        _IServicioCAD.Modify (servicioEN);

        /*PROTECTED REGION END*/
}
}
}
