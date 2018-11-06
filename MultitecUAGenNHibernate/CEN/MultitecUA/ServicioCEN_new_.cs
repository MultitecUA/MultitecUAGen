
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Servicio_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class ServicioCEN
{
public int New_ (string p_nombre, string p_descripcion, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum p_estado, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Servicio_new__customized) START*/

        ServicioEN servicioEN = null;

        int oid;

        //Initialized ServicioEN
        servicioEN = new ServicioEN ();
        servicioEN.Nombre = p_nombre;

        servicioEN.Descripcion = p_descripcion;

        servicioEN.Estado = p_estado;

        servicioEN.Fotos = p_fotos;

        //Call to ServicioCAD

        oid = _IServicioCAD.New_ (servicioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
