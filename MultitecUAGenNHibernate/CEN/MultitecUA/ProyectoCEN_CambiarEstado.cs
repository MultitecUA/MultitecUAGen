
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Proyecto_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class ProyectoCEN
{
public void CambiarEstado (int p_Proyecto_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum p_estado)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Proyecto_cambiarEstado_customized) START*/

        ProyectoEN proyectoEN = null;

        //Initialized ProyectoEN
        proyectoEN = new ProyectoEN ();
        proyectoEN.Id = p_Proyecto_OID;
        proyectoEN.Estado = p_estado;
        //Call to ProyectoCAD

        _IProyectoCAD.CambiarEstado (proyectoEN);

        /*PROTECTED REGION END*/
}
}
}
