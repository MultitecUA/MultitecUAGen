using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerServicio
    {
        // Convierte en en lista
        public ProyectoModel ConvertENToModelUI(ProyectoEN en)
        {
            ProyectoModel serv = new ProyectoModel();
            // Modelo.Atributo = ProyectoEN.Atributo
            serv.Id = en.Id.ToString();
            serv.Nombre = en.Nombre;
            serv.Descripcion = en.Descripcion;
            
            return serv;


        }

        // Convierte listas en modelo
        public IList<ProyectoModel> ConvertListENToModel (IList<ServicioEN> ens){
            IList<ProyectoModel> servis = new List<ProyectoModel>();
            foreach (ServicioEN en in ens)
            {
                servis.Add(ConvertENToModelUI(en));
            }
            return servis;
        }
        
    }
}