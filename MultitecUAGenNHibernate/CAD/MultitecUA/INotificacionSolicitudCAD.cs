
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionSolicitudCAD
{
NotificacionSolicitudEN ReadOIDDefault (int id
                                        );

void ModifyDefault (NotificacionSolicitudEN notificacionSolicitud);

System.Collections.Generic.IList<NotificacionSolicitudEN> ReadAllDefault (int first, int size);



int New_ (NotificacionSolicitudEN notificacionSolicitud);

void Destroy (int id
              );
}
}
