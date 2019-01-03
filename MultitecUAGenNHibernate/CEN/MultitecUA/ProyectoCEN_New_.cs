
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Proyecto_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class ProyectoCEN
{
public int New_ (string p_nombre, string p_descripcion, int p_usuarioCreador, System.Collections.Generic.IList<string> p_fotos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Proyecto_new__customized) ENABLED START*/

        ProyectoEN proyectoEN = null;

        int oid;

        //Initialized ProyectoEN
        proyectoEN = new ProyectoEN ();
        proyectoEN.Nombre = p_nombre;

        proyectoEN.Descripcion = p_descripcion;

        proyectoEN.Estado = Enumerated.MultitecUA.EstadoProyectoEnum.Propuesto;


        if (p_usuarioCreador != -1) {
                proyectoEN.UsuarioCreador = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                proyectoEN.UsuarioCreador.Id = p_usuarioCreador;

                UsuarioEN usuarioEN = new UsuarioEN ();
                usuarioEN.Id = p_usuarioCreador;
        }

        proyectoEN.FotosProyecto = p_fotos;

        //Call to ProyectoCAD

        oid = _IProyectoCAD.New_ (proyectoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
