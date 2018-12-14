

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
 *      Definition of the class CategoriaUsuarioCEN
 *
 */
public partial class CategoriaUsuarioCEN
{
private ICategoriaUsuarioCAD _ICategoriaUsuarioCAD;

public CategoriaUsuarioCEN()
{
        this._ICategoriaUsuarioCAD = new CategoriaUsuarioCAD ();
}

public CategoriaUsuarioCEN(ICategoriaUsuarioCAD _ICategoriaUsuarioCAD)
{
        this._ICategoriaUsuarioCAD = _ICategoriaUsuarioCAD;
}

public ICategoriaUsuarioCAD get_ICategoriaUsuarioCAD ()
{
        return this._ICategoriaUsuarioCAD;
}

public int New_ (string p_nombre)
{
        CategoriaUsuarioEN categoriaUsuarioEN = null;
        int oid;

        //Initialized CategoriaUsuarioEN
        categoriaUsuarioEN = new CategoriaUsuarioEN ();
        categoriaUsuarioEN.Nombre = p_nombre;

        //Call to CategoriaUsuarioCAD

        oid = _ICategoriaUsuarioCAD.New_ (categoriaUsuarioEN);
        return oid;
}

public void Modify (int p_CategoriaUsuario_OID, string p_nombre)
{
        CategoriaUsuarioEN categoriaUsuarioEN = null;

        //Initialized CategoriaUsuarioEN
        categoriaUsuarioEN = new CategoriaUsuarioEN ();
        categoriaUsuarioEN.Id = p_CategoriaUsuario_OID;
        categoriaUsuarioEN.Nombre = p_nombre;
        //Call to CategoriaUsuarioCAD

        _ICategoriaUsuarioCAD.Modify (categoriaUsuarioEN);
}

public void Destroy (int id
                     )
{
        _ICategoriaUsuarioCAD.Destroy (id);
}

public CategoriaUsuarioEN ReadOID (int id
                                   )
{
        CategoriaUsuarioEN categoriaUsuarioEN = null;

        categoriaUsuarioEN = _ICategoriaUsuarioCAD.ReadOID (id);
        return categoriaUsuarioEN;
}

public System.Collections.Generic.IList<CategoriaUsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CategoriaUsuarioEN> list = null;

        list = _ICategoriaUsuarioCAD.ReadAll (first, size);
        return list;
}
}
}
