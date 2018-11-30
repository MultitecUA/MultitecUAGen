
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


/*PROTECTED REGION ID(usingMultitecUAGenNHibernate.CEN.MultitecUA_Evento_dameEventosFiltrados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace MultitecUAGenNHibernate.CEN.MultitecUA
{
public partial class EventoCEN
{
public System.Collections.Generic.IList<MultitecUAGenNHibernate.EN.MultitecUA.EventoEN> DameEventosFiltrados (int p_categoria, Nullable<DateTime> p_fecha_anterior, Nullable<DateTime> p_fecha_posterior)
{
        /*PROTECTED REGION ID(MultitecUAGenNHibernate.CEN.MultitecUA_Evento_dameEventosFiltrados_customized) ENABLED START*/

        if (p_fecha_anterior == null)
                p_fecha_anterior = DateTime.Parse ("01/01/9999");

        if (p_fecha_posterior == null)
                p_fecha_posterior = DateTime.Parse ("01/01/1753");

        if (p_categoria != -1)
                return _IEventoCAD.DameEventosFiltrados (p_categoria, p_fecha_anterior, p_fecha_posterior);
        else{
                List<int> listaCategorias = new List<int>();
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN ();
                foreach (CategoriaProyectoEN categoria in categoriaProyectoCEN.ReadAll (0, -1))
                        listaCategorias.Add (categoria.Id);

                List<EventoEN> listaEventos = new List<EventoEN>();

                foreach (int oid_categoria in listaCategorias)
                        listaEventos.AddRange (_IEventoCAD.DameEventosFiltrados (oid_categoria, p_fecha_anterior, p_fecha_posterior));

                return listaEventos;
        }
        /*PROTECTED REGION END*/
}
}
}
