
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionCAD
{
NotificacionEN ReadOIDDefault (int id
                               );

void ModifyDefault (NotificacionEN notificacion);

System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size);



int New_ (NotificacionEN notificacion);

void Destroy (int id
              );


NotificacionEN ReadOID (int id
                        );


System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size);
}
}
