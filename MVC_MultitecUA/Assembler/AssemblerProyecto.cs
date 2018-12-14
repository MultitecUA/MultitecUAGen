using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerProyecto
    {
        // Convierte en en lista
        public ProyectoModel ConvertENToModelUI(ProyectoEN en)
        {
            ProyectoModel serv = new ProyectoModel();
            
            //serv.Id = en.Id.ToString();
            serv.usuarioId = en.UsuarioCreador.Id;
            serv.Nombre = en.Nombre;
            serv.Descripcion = en.Descripcion;
            
            return serv;


        }

        // Convierte listas en modelo
        public IList<ProyectoModel> ConvertListENToModel (IList<ProyectoEN> ens){
            IList<ProyectoModel> servis = new List<ProyectoModel>();
            foreach (ProyectoEN en in ens)
            {
                servis.Add(ConvertENToModelUI(en));
            }
            return servis;
        }
        
    }
}