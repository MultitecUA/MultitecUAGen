
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

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorEstado (int p_OIDProyecto, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum ? p_estado);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorUsuario (int p_OID);




System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicidudesPorUsuarioYProyecto (int p_proyecto, int p_usuario);
}
}
