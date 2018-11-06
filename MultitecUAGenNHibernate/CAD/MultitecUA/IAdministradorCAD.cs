
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (int id
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



int New_ (AdministradorEN administrador);

void Destroy (int id
              );


AdministradorEN ReadOID (int id
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
