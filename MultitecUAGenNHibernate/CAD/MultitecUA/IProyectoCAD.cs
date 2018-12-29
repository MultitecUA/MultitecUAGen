
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IProyectoCAD
{
ProyectoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProyectoEN proyecto);

System.Collections.Generic.IList<ProyectoEN> ReadAllDefault (int first, int size);



int New_ (ProyectoEN proyecto);

void Modify (ProyectoEN proyecto);


void Destroy (int id
              );


void CambiarEstado (ProyectoEN proyecto);


void AgregaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_Usuarios_OIDs);

void AgregaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosUsuarioPertenece (int p_OID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEvento (int p_OID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorCategoria (int p_OID_Categoria);


void AgregaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs);

void AgregaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs);

void AgregaParticipantes (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs);

void EliminaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosModeradores_OIDs);

void EliminaEventos (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs);

void EliminaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs);

void EliminaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs);

void EliminaParticipantes (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum ? p_estado);


ProyectoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProyectoEN> ReadAll (int first, int size);


MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ReadNombre (string p_nombre);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorNombre (string p_nombre);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorCategoriaUsuario (int p_OID_Categoria);
}
}
