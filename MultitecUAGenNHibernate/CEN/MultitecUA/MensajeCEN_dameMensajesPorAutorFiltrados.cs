
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_dameMensajesPorAutorFiltrados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorFiltrados (int p_oid_usuario, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum ? p_bandeja)
{
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_dameMensajesPorAutorFiltrados_customized) START*/

            if (p_fecha_anterior == null)
                p_fecha_anterior = DateTime.Parse("01/01/9999");

            if (p_fecha_posterior == null)
                p_fecha_posterior = DateTime.Parse("01/01/1753");

            return _IMensajeCAD.DameMensajesPorAutorFiltrados (p_oid_usuario, p_fecha_anterior, p_fecha_posterior, p_bandeja);
            /*PROTECTED REGION END*/
}
}
}
