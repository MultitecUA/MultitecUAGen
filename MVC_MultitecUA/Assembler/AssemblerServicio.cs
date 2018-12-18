using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerServicio
    {
        public Servicio ConvertENToModelUI(ServicioEN en)
        {
            Servicio serv = new Servicio();
            serv.Id = en.Id.ToString();
            serv.Nombre = en.Nombre;
            serv.Descripcion = en.Descripcion;
            serv.Estado = en.Estado;
            
            return serv;


        }
        public IList<Servicio> ConvertListENToModel (IList<ServicioEN> ens){
            IList<Servicio> servis = new List<Servicio>();
            foreach (ServicioEN en in ens)
            {
                servis.Add(ConvertENToModelUI(en));
            }
            return servis;
        }
        
    }
}