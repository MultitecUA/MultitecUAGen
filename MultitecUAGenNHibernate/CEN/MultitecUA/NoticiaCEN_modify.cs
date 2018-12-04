
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Noticia_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NoticiaCEN
{
public void Modify (int p_Noticia_OID, string p_titulo, string p_cuerpo, string p_foto)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Noticia_modify_customized) START*/

        NoticiaEN noticiaEN = null;

        //Initialized NoticiaEN
        noticiaEN = new NoticiaEN ();
        noticiaEN.Id = p_Noticia_OID;
        noticiaEN.Titulo = p_titulo;
        noticiaEN.Cuerpo = p_cuerpo;
        noticiaEN.Foto = p_foto;
        //Call to NoticiaCAD

        _INoticiaCAD.Modify (noticiaEN);

        /*PROTECTED REGION END*/
}
}
}
