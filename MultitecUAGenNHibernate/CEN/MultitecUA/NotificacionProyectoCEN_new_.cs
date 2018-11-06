
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_NotificacionProyecto_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class NotificacionProyectoCEN
{
public int New_ (string p_titulo, string p_mensaje, int p_proyectoGenerador)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_NotificacionProyecto_new__customized) START*/

        NotificacionProyectoEN notificacionProyectoEN = null;

        int oid;

        //Initialized NotificacionProyectoEN
        notificacionProyectoEN = new NotificacionProyectoEN ();
        notificacionProyectoEN.Titulo = p_titulo;

        notificacionProyectoEN.Mensaje = p_mensaje;


        if (p_proyectoGenerador != -1) {
                notificacionProyectoEN.ProyectoGenerador = new MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ();
                notificacionProyectoEN.ProyectoGenerador.Id = p_proyectoGenerador;
        }

        //Call to NotificacionProyectoCAD

        oid = _INotificacionProyectoCAD.New_ (notificacionProyectoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
