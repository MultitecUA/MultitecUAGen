
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Noticia_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NoticiaCEN
{
public int New_ (string p_titulo, string p_cuerpo, string p_foto)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Noticia_new__customized) ENABLED START*/

        NoticiaEN noticiaEN = null;

        int oid;

        //Initialized NoticiaEN
        noticiaEN = new NoticiaEN ();
        noticiaEN.Titulo = p_titulo;

        noticiaEN.Cuerpo = p_cuerpo;

        noticiaEN.FotoNoticia = p_foto;

        noticiaEN.Fecha = DateTime.Now;

        //Call to NoticiaCAD

        oid = _INoticiaCAD.New_ (noticiaEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
