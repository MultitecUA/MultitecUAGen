
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface INoticiaCAD
{
NoticiaEN ReadOIDDefault (int id
                          );

void ModifyDefault (NoticiaEN noticia);

System.Collections.Generic.IList<NoticiaEN> ReadAllDefault (int first, int size);



int New_ (NoticiaEN noticia);

void Modify (NoticiaEN noticia);


void Destroy (int id
              );


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN> DameNUltimasNoticias (int ? p_n);


NoticiaEN ReadOID (int id
                   );


System.Collections.Generic.IList<NoticiaEN> ReadAll (int first, int size);
}
}
