
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_dameMensajesPorReceptorFiltrados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorFiltrados (int p_oid_usuario, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posteror, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum ? p_bandeja)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_dameMensajesPorReceptorFiltrados_customized) START*/

        return _IMensajeCAD.DameMensajesPorReceptorFiltrados (p_oid_usuario, p_fecha_anterior, p_fecha_posteror, p_bandeja);
        /*PROTECTED REGION END*/
}
}
}
