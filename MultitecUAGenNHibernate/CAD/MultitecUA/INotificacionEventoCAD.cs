
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionEventoCAD
{
NotificacionEventoEN ReadOIDDefault (int id
                                     );

void ModifyDefault (NotificacionEventoEN notificacionEvento);

System.Collections.Generic.IList<NotificacionEventoEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEventoEN notificacionEvento);

NotificacionEventoEN ReadOID (int id
                              );


System.Collections.Generic.IList<NotificacionEventoEN> ReadAll (int first, int size);


void Destroy (int id
              );
}
}
