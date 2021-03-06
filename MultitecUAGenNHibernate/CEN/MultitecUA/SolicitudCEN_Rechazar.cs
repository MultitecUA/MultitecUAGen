
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_rechazar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class SolicitudCEN
{
public void Rechazar (int p_oid)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Solicitud_rechazar) ENABLED START*/

        SolicitudCAD solicitudCAD = new SolicitudCAD ();
        SolicitudEN solicitudEN = solicitudCAD.ReadOIDDefault (p_oid);

        solicitudEN.Estado = Enumerated.MultitecUA.EstadoSolicitudEnum.Rechazada;

        solicitudCAD.ModifyDefault (solicitudEN);

        /*PROTECTED REGION END*/
}
}
}
