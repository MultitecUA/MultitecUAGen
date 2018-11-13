

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public void Destroy (int id
                     )
{
        _IUsuarioCAD.Destroy (id);
}

public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Password.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosCandidatos (System.Collections.Generic.IList<int> p_OIDCategoria, int p_OIDProyecto)
{
        return _IUsuarioCAD.DameUsuariosCandidatos (p_OIDCategoria, p_OIDProyecto);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameModeradoresProyecto (int p_ID)
{
        return _IUsuarioCAD.DameModeradoresProyecto (p_ID);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameParticipantesProyecto (int p_ID)
{
        return _IUsuarioCAD.DameParticipantesProyecto (p_ID);
}
public void AgregaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AgregaCategorias (p_Usuario_OID, p_categoriasUsuarios_OIDs);
}
public void EliminaCategorias (int p_Usuario_OID, System.Collections.Generic.IList<int> p_categoriasUsuarios_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.EliminaCategorias (p_Usuario_OID, p_categoriasUsuarios_OIDs);
}
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.UsuarioEN> DameUsuariosPorCategoria (int p_categoria)
{
        return _IUsuarioCAD.DameUsuariosPorCategoria (p_categoria);
}



private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
