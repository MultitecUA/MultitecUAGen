
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



/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CP.MultitecUA_Mensaje_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CP.MultitecUA
{
public partial class MensajeCP : BasicCP
{
public MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN New_ (string p_titulo, string p_cuerpo, int p_usuarioAutor, int p_usuarioReceptor, System.Collections.Generic.IList<string> p_archivosAdjuntos)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CP.MultitecUA_Mensaje_new_) ENABLED START*/

        IMensajeCAD mensajeCAD = null;
        MensajeCEN mensajeCEN = null;

        MultitecUAGenNHibernate.EN.MultitecUA.MensajeEN result = null;


        try
        {
                SessionInitializeTransaction ();
                mensajeCAD = new MensajeCAD (session);
                mensajeCEN = new  MensajeCEN (mensajeCAD);




                int oid;
                //Initialized MensajeEN
                MensajeEN mensajeEN;
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

                //Call to MensajeCAD

                oid = mensajeCAD.New_ (mensajeEN);
                result = mensajeCAD.ReadOIDDefault (oid);



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
