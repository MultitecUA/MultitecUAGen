
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IMensajeCAD
{
MensajeEN ReadOIDDefault (int id
                          );

void ModifyDefault (MensajeEN mensaje);

System.Collections.Generic.IList<MensajeEN> ReadAllDefault (int first, int size);



int New_ (MensajeEN mensaje);

void Destroy (int id
              );


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesRecibidos (int p_oid_usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesEnviados (int p_oid_usuario);



MensajeEN ReadOID (int id
                   );


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);




System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMisMensajesNuevos (int p_oid_usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesEnviadosPosterioresA (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesEnviadosAnterioresA (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesRecibidosPosterioresA (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesRecibidosAnterioresA (Nullable<DateTime> p_fecha);
}
}
