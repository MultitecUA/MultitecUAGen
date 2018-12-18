

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
 *      Definition of the class ProyectoCEN
 *
 */
public partial class ProyectoCEN
{
private IProyectoCAD _IProyectoCAD;

public ProyectoCEN()
{
        this._IProyectoCAD = new ProyectoCAD ();
}

public ProyectoCEN(IProyectoCAD _IProyectoCAD)
{
        this._IProyectoCAD = _IProyectoCAD;
}

public IProyectoCAD get_IProyectoCAD ()
{
        return this._IProyectoCAD;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosUsuarioPertenece (int p_OID)
{
        return _IProyectoCAD.DameProyectosUsuarioPertenece (p_OID);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEvento (int p_OID)
{
        return _IProyectoCAD.DameProyectosPorEvento (p_OID);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorCategoria (int p_OID_Categoria)
{
        return _IProyectoCAD.DameProyectosPorCategoria (p_OID_Categoria);
}
public void AgregaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs)
{
        //Call to ProyectoCAD

        _IProyectoCAD.AgregaCategoriasUsuario (p_Proyecto_OID, p_categoriasBuscadas_OIDs);
}
public void AgregaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs)
{
        //Call to ProyectoCAD

        _IProyectoCAD.AgregaCategoriasProyecto (p_Proyecto_OID, p_categoriasProyectos_OIDs);
}
public void EliminaCategoriasUsuario (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasBuscadas_OIDs)
{
        //Call to ProyectoCAD

        _IProyectoCAD.EliminaCategoriasUsuario (p_Proyecto_OID, p_categoriasBuscadas_OIDs);
}
public void EliminaCategoriasProyecto (int p_Proyecto_OID, System.Collections.Generic.IList<int> p_categoriasProyectos_OIDs)
{
        //Call to ProyectoCAD

        _IProyectoCAD.EliminaCategoriasProyecto (p_Proyecto_OID, p_categoriasProyectos_OIDs);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum ? p_estado)
{
        return _IProyectoCAD.DameProyectosPorEstado (p_estado);
}
public ProyectoEN ReadOID (int id
                           )
{
        ProyectoEN proyectoEN = null;

        proyectoEN = _IProyectoCAD.ReadOID (id);
        return proyectoEN;
}

public System.Collections.Generic.IList<ProyectoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProyectoEN> list = null;

        list = _IProyectoCAD.ReadAll (first, size);
        return list;
}
public MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN ReadNombre (string p_nombre)
{
        return _IProyectoCAD.ReadNombre (p_nombre);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DameProyectosPorNombre (string p_nombre)
{
        return _IProyectoCAD.DameProyectosPorNombre (p_nombre);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.ProyectoEN> DamePoyectosPorCategoriaUsuario (int p_OID_Categoria)
{
        return _IProyectoCAD.DamePoyectosPorCategoriaUsuario (p_OID_Categoria);
}
}
}
