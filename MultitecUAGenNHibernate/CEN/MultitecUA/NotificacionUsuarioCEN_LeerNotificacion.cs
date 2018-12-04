
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionUsuario_leerNotificacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
    public partial class NotificacionUsuarioCEN
    {
        public void LeerNotificacion(int p_NotificacionUsuario_OID)
        {
            /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionUsuario_leerNotificacion_customized) START*/

            NotificacionUsuarioEN notificacionUsuarioEN = null;
            NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();

            //Initialized NotificacionUsuarioEN
            notificacionUsuarioEN = notificacionUsuarioCEN.ReadOID(p_NotificacionUsuario_OID);
            notificacionUsuarioEN.Estado = Enumerated.MultitecUA.EstadoLecturaEnum.Leido;
            //Call to NotificacionUsuarioCAD

            _INotificacionUsuarioCAD.ModifyDefault(notificacionUsuarioEN);

            /*PROTECTED REGION END*/
        }
    }
}
