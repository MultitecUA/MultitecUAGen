
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using MultitecUAGenNHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;



namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class ServicioCP : BasicCP
{
public ServicioCP() : base ()
{
}

public ServicioCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
