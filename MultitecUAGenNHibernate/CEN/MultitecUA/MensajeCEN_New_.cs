
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public int New_ (string p_titulo, string p_cuerpo, int p_usuarioAutor, int p_usuarioReceptor, System.Collections.Generic.IList<string> p_archivosAdjuntos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_new__customized) ENABLED START*/

        MensajeEN mensajeEN = null;

        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Titulo = p_titulo;

        mensajeEN.Cuerpo = p_cuerpo;


        if (p_usuarioAutor != -1) {
                mensajeEN.UsuarioAutor = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                mensajeEN.UsuarioAutor.Id = p_usuarioAutor;
        }


        if (p_usuarioReceptor != -1) {
                mensajeEN.UsuarioReceptor = new MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN ();
                mensajeEN.UsuarioReceptor.Id = p_usuarioReceptor;
        }

        mensajeEN.ArchivosAdjuntos = p_archivosAdjuntos;

        mensajeEN.Fecha = DateTime.Now;

        mensajeEN.EstadoLecutra = Enumerated.MultitecUA.EstadoLecturaEnum.NoLeido;

        mensajeEN.BandejaAutor = Enumerated.MultitecUA.BandejaMensajeEnum.Activo;

        mensajeEN.BandejaReceptor = Enumerated.MultitecUA.BandejaMensajeEnum.Activo;

        //Call to MensajeCAD

        oid = _IMensajeCAD.New_ (mensajeEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
