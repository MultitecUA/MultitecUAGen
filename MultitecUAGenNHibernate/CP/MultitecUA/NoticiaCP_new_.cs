
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Noticia_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class NoticiaCP : BasicCP
{
public MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN New_ (string p_titulo, string p_cuerpo, string p_foto)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Noticia_new_) ENABLED START*/

        INoticiaCAD noticiaCAD = null;
        NoticiaCEN noticiaCEN = null;

        MultitecUAGenNHibernate.EN.MultitecUA.NoticiaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                noticiaCAD = new NoticiaCAD (session);
                noticiaCEN = new  NoticiaCEN (noticiaCAD);




                int oid;
                //Initialized NoticiaEN
                NoticiaEN noticiaEN;
                noticiaEN = new NoticiaEN ();
                noticiaEN.Titulo = p_titulo;

                noticiaEN.Cuerpo = p_cuerpo;

                noticiaEN.Foto = p_foto;

                //Call to NoticiaCAD

                oid = noticiaCAD.New_ (noticiaEN);
                result = noticiaCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
