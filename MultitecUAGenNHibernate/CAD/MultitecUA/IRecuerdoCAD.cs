
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IRecuerdoCAD
{
RecuerdoEN ReadOIDDefault (int id
                           );

void ModifyDefault (RecuerdoEN recuerdo);

System.Collections.Generic.IList<RecuerdoEN> ReadAllDefault (int first, int size);



int New_ (RecuerdoEN recuerdo);

void Modify (RecuerdoEN recuerdo);


void Destroy (int id
              );


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.RecuerdoEN> DameRecuerdos (int p_OID);
}
}
