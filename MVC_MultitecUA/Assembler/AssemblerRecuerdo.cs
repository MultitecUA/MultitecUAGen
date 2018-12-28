using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultitecUAGenNHibernate.EN.MultitecUA;

namespace MVC_MultitecUA.Models
{
    public class AssemblerRecuerdo
    {
        public Recuerdo ConvertENToModelUI(RecuerdoEN en)
        {
            Recuerdo serv = new Recuerdo();
            serv.Id = en.Id.ToString();
            serv.IdEvento = en.EventoRecordado.Id;
            //serv.NombreEvento = en.EventoRecordado.Nombre;
            serv.Titulo = en.Titulo;
            serv.Cuerpo = en.Cuerpo;
            
            return serv;


        }
        public IList<Recuerdo> ConvertListENToModel (IList<RecuerdoEN> ens){
            IList<Recuerdo> recuerdos = new List<Recuerdo>();
            foreach (RecuerdoEN en in ens)
            {
                recuerdos.Add(ConvertENToModelUI(en));
            }
            return recuerdos;
        }
        
    }
}