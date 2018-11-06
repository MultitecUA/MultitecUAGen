
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INotificacionUsuarioCAD
{
NotificacionUsuarioEN ReadOIDDefault (int id
                                      );

void ModifyDefault (NotificacionUsuarioEN notificacionUsuario);

System.Collections.Generic.IList<NotificacionUsuarioEN> ReadAllDefault (int first, int size);



int New_ (NotificacionUsuarioEN notificacionUsuario);

void Destroy (int id
              );



NotificacionUsuarioEN ReadOID (int id
                               );


System.Collections.Generic.IList<NotificacionUsuarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameMisNotificaciones (int p_oid_usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NotificacionUsuarioEN> DameMisNotificacionesNuevas (int p_oid_usuario);
}
}
