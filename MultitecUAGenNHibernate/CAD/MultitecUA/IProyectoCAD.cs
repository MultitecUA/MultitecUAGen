
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



void AgregaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_Usuarios_OIDs);

void AgregaEvento (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosUsuarioPertenece (int p_OID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosUsuarioEsCandidato (System.Collections.Generic.IList<int> p_OIDCategorias, int p_OIDUsuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEvento (int p_OID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorCategoria (System.Collections.Generic.IList<int> p_OID_Categoria);


void AgregaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs);

void AgregaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs);

void AgregaParticipante (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs);

void EliminaModeradores (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosModeradores_OIDs);

void EliminaEvento (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_eventosAsociados_OIDs);

void EliminaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs);

void EliminaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs);

void EliminaParticipante (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_usuariosParticipantes_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum ? p_estado);
}
}
