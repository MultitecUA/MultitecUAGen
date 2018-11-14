
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Evento_dameEventosFiltrados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class EventoCEN
{
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosFiltrados (int p_categoria, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Evento_dameEventosFiltrados_customized) START*/

        return _IEventoCAD.DameEventosFiltrados (p_categoria, p_fecha_anterior, p_fecha_posterior);
        /*PROTECTED REGION END*/
}
}
}
