
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class UsuarioCEN
{
public int New_ (string p_nombre, String p_password, string p_foto, string p_email, string p_nick)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Usuario_new__customized) ENABLED START*/

        UsuarioEN usuarioEN = null;

        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Foto = p_foto;

        usuarioEN.Email = p_email;

        usuarioEN.Nick = p_nick;

        usuarioEN.FechaAlta = DateTime.Now;

        usuarioEN.Rol = Enumerated.MultitecUA.RolUsuarioEnum.Miembro;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
