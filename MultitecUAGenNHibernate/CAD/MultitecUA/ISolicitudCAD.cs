
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface ISolicitudCAD
{
SolicitudEN ReadOIDDefault (int id
                            );

void ModifyDefault (SolicitudEN solicitud);

System.Collections.Generic.IList<SolicitudEN> ReadAllDefault (int first, int size);



int New_ (SolicitudEN solicitud);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPendientes (int p_OIDProyecto);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameMisSolicitudes (int p_OID);




SolicitudEN ReadOID (int id
                     );


System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesRechazadas (int p_OIDProyecto);
}
}
