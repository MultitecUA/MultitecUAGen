
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionMensajeCAD
{
NotificacionMensajeEN ReadOIDDefault (int id
                                      );

void ModifyDefault (NotificacionMensajeEN notificacionMensaje);

System.Collections.Generic.IList<NotificacionMensajeEN> ReadAllDefault (int first, int size);



int New_ (NotificacionMensajeEN notificacionMensaje);

void Destroy (int id
              );
}
}
