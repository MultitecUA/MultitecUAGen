
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


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosFiltrados (int p_categoria, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior);


void AgregaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs);

void EliminaCategorias (int p_Evento_OID, System.Collections.Generic.IList<int> p_categoriasEventos_OIDs);

EventoEN ReadOID (int id
                  );


System.Collections.Generic.IList<EventoEN> ReadAll (int first, int size);



void EliminaProyectosAsociados (int p_Evento_OID, System.Collections.Generic.IList<int> p_proyectosPresentados_OIDs);

MultitecUAGenNHibernate.EN.MultitecUA.EventoEN ReadNombre (string p_nombre);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosPorNombre (string p_nombre);
}
}
