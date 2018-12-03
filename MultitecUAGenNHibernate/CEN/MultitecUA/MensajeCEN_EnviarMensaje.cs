
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_enviarMensaje) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class MensajeCEN
{
public void EnviarMensaje (int p_oid)
{
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Mensaje_enviarMensaje) ENABLED START*/


            NotificacionMensajeCEN notificacionMensajeCEN = new NotificacionMensajeCEN();
            int OID_notificacionMensaje = notificacionMensajeCEN.New_("Nuevo mensaje", "Tienes un nuevo mensaje", p_oid);

            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();

            MensajeCEN mensajeCEN = new MensajeCEN();
            MensajeEN mensaje = mensajeCEN.ReadOID(p_oid);

            notificacionUsuarioCEN.New_(mensaje.UsuarioReceptor.Id, OID_notificacionMensaje);
        

        /*PROTECTED REGION END*/
}
}
}
