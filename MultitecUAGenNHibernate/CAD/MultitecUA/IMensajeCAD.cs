
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


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptor (int p_oid_usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutor (int p_oid_usuario);


void CambiarEstado (MensajeEN mensaje);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorReceptorFiltrados (int p_oid_usuario, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posteror, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum ? p_bandeja);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN> DameMensajesPorAutorFiltrados (int p_oid_usuario, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum ? p_bandeja);


void CambiarBandejaReceptor (MensajeEN mensaje);


void CambiarBandejaAutor (MensajeEN mensaje);


MensajeEN ReadOID (int id
                   );


System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size);
}
}
