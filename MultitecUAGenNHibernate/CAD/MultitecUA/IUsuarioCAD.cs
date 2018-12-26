
using System;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MultitecUAGenNHibernate.CAD.MultitecUA
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);



System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameModeradoresProyecto (int p_ID);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameParticipantesProyecto (int p_ID);


void AgregaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs);

void EliminaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs);

System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosPorCategoria (int p_categoria);


void CambiarRol (UsuarioEN usuario);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosPorRol (MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum ? p_rol);


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ReadNick (string p_nick);


System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosPorNick (string p_nick);


void Destroy (int id
              );
}
}
