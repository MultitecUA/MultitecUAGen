

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using MultitecUAGenNHibernate.Exceptions;

using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;


namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
/*
 *      Definition of the class SolicitudCEN
 *
 */
public partial class SolicitudCEN
{
private ISolicitudCAD _ISolicitudCAD;

public SolicitudCEN()
{
        this._ISolicitudCAD = new SolicitudCAD ();
}

public SolicitudCEN(ISolicitudCAD _ISolicitudCAD)
{
        this._ISolicitudCAD = _ISolicitudCAD;
}

public ISolicitudCAD get_ISolicitudCAD ()
{
        return this._ISolicitudCAD;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorProyectoYEstado (int p_OIDProyecto, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum ? p_estado)
{
        return _ISolicitudCAD.DameSolicitudesPorProyectoYEstado (p_OIDProyecto, p_estado);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPorUsuarioYEstado (int p_OID, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum ? p_estado)
{
        return _ISolicitudCAD.DameSolicitudesPorUsuarioYEstado (p_OID, p_estado);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicidudesPorUsuarioYProyecto (int p_proyecto, int p_usuario)
{
        return _ISolicitudCAD.DameSolicidudesPorUsuarioYProyecto (p_proyecto, p_usuario);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.SolicitudEN> DameSolicitudesPendientesPorProyectoDe (int p_proyecto, int p_usuario)
{
        return _ISolicitudCAD.DameSolicitudesPendientesPorProyectoDe (p_proyecto, p_usuario);
}
public SolicitudEN ReadOID (int id
                            )
{
        SolicitudEN solicitudEN = null;

        solicitudEN = _ISolicitudCAD.ReadOID (id);
        return solicitudEN;
}

public System.Collections.Generic.IList<SolicitudEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SolicitudEN> list = null;

        list = _ISolicitudCAD.ReadAll (first, size);
        return list;
}
}
}
