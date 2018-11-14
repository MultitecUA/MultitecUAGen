
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Noticia_dameNUltimasNoticias) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NoticiaCEN
{
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN> DameNUltimasNoticias (int ? p_n)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Noticia_dameNUltimasNoticias_customized) START*/

        return _INoticiaCAD.DameNUltimasNoticias (p_n);
        /*PROTECTED REGION END*/
}
}
}
