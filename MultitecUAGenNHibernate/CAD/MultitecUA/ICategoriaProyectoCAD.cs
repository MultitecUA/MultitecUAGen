
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface ICategoriaProyectoCAD
{
CategoriaProyectoEN ReadOIDDefault (int id
                                    );

void ModifyDefault (CategoriaProyectoEN categoriaProyecto);

System.Collections.Generic.IList<CategoriaProyectoEN> ReadAllDefault (int first, int size);



int New_ (CategoriaProyectoEN categoriaProyecto);

void Modify (CategoriaProyectoEN categoriaProyecto);


void Destroy (int id
              );
}
}
