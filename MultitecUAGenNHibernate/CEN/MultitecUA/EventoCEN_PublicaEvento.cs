
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Evento_publicaEvento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class EventoCEN
{
public void PublicaEvento (int p_oid)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Evento_publicaEvento) ENABLED START*/
        EventoEN eventoEN = ReadOID (p_oid);
        NotificacionEventoCEN notificacionEventoCEN = new NotificacionEventoCEN ();
        int OID_notificacionEvento = notificacionEventoCEN.New_ ("Nuevo evento publicado", "Se acaba de publicar un nuevo evento: " + eventoEN.Nombre, eventoEN.Id);

        UsuarioCEN usuarioCEN = new UsuarioCEN ();
        NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();

        List<int> listaOIDsUsuarios = new List<int>();

        foreach (UsuarioEN usuarioEN in usuarioCEN.ReadAll (0, -1))
                listaOIDsUsuarios.Add (usuarioEN.Id);

        foreach (int OIDUsuario in listaOIDsUsuarios)
                notificacionUsuarioCEN.New_ (OIDUsuario, OID_notificacionEvento);


        /*PROTECTED REGION END*/
}
}
}
