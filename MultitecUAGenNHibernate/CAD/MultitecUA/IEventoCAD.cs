
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IEventoCAD
{
EventoEN ReadOIDDefault (int id
                         );

void ModifyDefault (EventoEN evento);

System.Collections.Generic.IList<EventoEN> ReadAllDefault (int first, int size);



int New_ (EventoEN evento);

void Modify (EventoEN evento);


void Destroy (int id
              );


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorProyecto (int p_OID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorCategoria (System.Collections.Generic.IList<int> p_OID);


void AgregaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs);

void EliminaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPosterioresA (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosAnterioresA (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosAbiertos (Nullable<DateTime> p_fecha);
}
}
