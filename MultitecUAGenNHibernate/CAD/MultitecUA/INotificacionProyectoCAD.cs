
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionProyectoCAD
{
NotificacionProyectoEN ReadOIDDefault (int id
                                       );

void ModifyDefault (NotificacionProyectoEN notificacionProyecto);

System.Collections.Generic.IList<NotificacionProyectoEN> ReadAllDefault (int first, int size);



int New_ (NotificacionProyectoEN notificacionProyecto);

void Destroy (int id
              );
}
}
