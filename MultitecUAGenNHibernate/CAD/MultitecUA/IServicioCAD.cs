
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IServicioCAD
{
ServicioEN ReadOIDDefault (int id
                           );

void ModifyDefault (ServicioEN servicio);

System.Collections.Generic.IList<ServicioEN> ReadAllDefault (int first, int size);



int New_ (ServicioEN servicio);

void Modify (ServicioEN servicio);


void Destroy (int id
              );


void CambiarDisponibilidad (ServicioEN servicio);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ServicioEN> DameServiciosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum ? p_estado);
}
}
