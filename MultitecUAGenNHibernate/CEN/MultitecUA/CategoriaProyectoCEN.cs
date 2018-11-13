

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
 *      Definition of the class CategoriaProyectoCEN
 *
 */
public partial class CategoriaProyectoCEN
{
private ICategoriaProyectoCAD _ICategoriaProyectoCAD;

public CategoriaProyectoCEN()
{
        this._ICategoriaProyectoCAD = new CategoriaProyectoCAD ();
}

public CategoriaProyectoCEN(ICategoriaProyectoCAD _ICategoriaProyectoCAD)
{
        this._ICategoriaProyectoCAD = _ICategoriaProyectoCAD;
}

public ICategoriaProyectoCAD get_ICategoriaProyectoCAD ()
{
        return this._ICategoriaProyectoCAD;
}

public int New_ (string p_nombre)
{
        CategoriaProyectoEN categoriaProyectoEN = null;
        int oid;

        //Initialized CategoriaProyectoEN
        categoriaProyectoEN = new CategoriaProyectoEN ();
        categoriaProyectoEN.Nombre = p_nombre;

        //Call to CategoriaProyectoCAD

        oid = _ICategoriaProyectoCAD.New_ (categoriaProyectoEN);
        return oid;
}

public void Modify (int p_CategoriaProyecto_OID, string p_nombre)
{
        CategoriaProyectoEN categoriaProyectoEN = null;

        //Initialized CategoriaProyectoEN
        categoriaProyectoEN = new CategoriaProyectoEN ();
        categoriaProyectoEN.Id = p_CategoriaProyecto_OID;
        categoriaProyectoEN.Nombre = p_nombre;
        //Call to CategoriaProyectoCAD

        _ICategoriaProyectoCAD.Modify (categoriaProyectoEN);
}

public void Destroy (int id
                     )
{
        _ICategoriaProyectoCAD.Destroy (id);
}
}
}
