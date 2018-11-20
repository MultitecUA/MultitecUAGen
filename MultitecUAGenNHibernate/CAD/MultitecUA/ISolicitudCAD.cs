
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

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorProyectoYEstado (int p_OIDProyecto, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum ? p_estado);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorUsuarioYEstado (int p_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum ? p_estado);




System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicidudesPorUsuarioYProyecto (int p_proyecto, int p_usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPendientesPorProyectoDe (int p_proyecto, int p_usuario);


SolicitudEN ReadOID (int id
                     );


System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size);
}
}
