
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


CategoriaProyectoEN ReadOID (int id
                             );


System.Collections.Generic.IList<CategoriaProyectoEN> ReadAll (int first, int size);


MultitecUAGenNHibernate.EN.MultitecUA.CategoriaProyectoEN ReadNombre (string p_nombre);
}
}
