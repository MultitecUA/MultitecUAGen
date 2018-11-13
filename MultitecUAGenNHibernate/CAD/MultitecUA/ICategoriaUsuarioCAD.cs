
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface ICategoriaUsuarioCAD
{
CategoriaUsuarioEN ReadOIDDefault (int id
                                   );

void ModifyDefault (CategoriaUsuarioEN categoriaUsuario);

System.Collections.Generic.IList<CategoriaUsuarioEN> ReadAllDefault (int first, int size);



int New_ (CategoriaUsuarioEN categoriaUsuario);

void Modify (CategoriaUsuarioEN categoriaUsuario);


void Destroy (int id
              );
}
}
