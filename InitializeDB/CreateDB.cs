
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                /*USUARIOS*/
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int OIDUsuario = usuarioCEN.New_ ("Judith", "12345", null, "judith@gmail.com", "BenhMM");
                usuarioCEN.Modify (OIDUsuario, "Victor", "54321", "nedyar@hotmail.es", "Nedyar94", null);
                Console.WriteLine ("Login key: " + usuarioCEN.Login (OIDUsuario, "54321"));
                //int OIDUsuarioABorrar = usuarioCEN.New_ ("Judith", "12345", null, "juditsdfh@gmail.com", "BenhasdfasdfMM");
                // en lugar de destroy tiene cambiar rol usuarioCEN.Destroy (OIDUsuarioABorrar);
                usuarioCEN.CambiarRol (OIDUsuario, MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum.Administrador);
                Console.WriteLine ("Administradores: " + usuarioCEN.DameUsuariosPorRol (MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum.Administrador).Count);
                Console.WriteLine ("Usuarios por nick: " + usuarioCEN.ReadNick ("Nedyar94"));

                /*CATEGORIAS DE USUARIOS*/
                CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN ();

                List<int> OIDsCategorias = new List<int>();
                int OIDCategoria = categoriaUsuarioCEN.New_ ("Programado");
                categoriaUsuarioCEN.Modify (OIDCategoria, "Programador");
                OIDsCategorias.Add (OIDCategoria);
                OIDCategoria = categoriaUsuarioCEN.New_ ("Dise�ador");
                OIDsCategorias.Add (OIDCategoria);
                OIDCategoria = categoriaUsuarioCEN.New_ ("Puto Amo");
                OIDsCategorias.Add (OIDCategoria);

                categoriaUsuarioCEN.Modify (OIDCategoria, "Putisimo Amo");

                //categoriaUsuarioCEN.Destroy (OIDCategoria);

                Console.WriteLine ("Categoria Usuario con OID " + OIDCategoria + ": " + categoriaUsuarioCEN.ReadOID (OIDCategoria).Id);
                usuarioCEN.AgregaCategorias (OIDUsuario, OIDsCategorias);

                OIDsCategorias.RemoveAt (2);
                usuarioCEN.EliminaCategorias (OIDUsuario, OIDsCategorias);

                Console.WriteLine ("Usuarios por categoria: " + usuarioCEN.DameUsuariosPorCategoria (OIDCategoria).Count);

                Console.WriteLine ("Usuarios totales: " + usuarioCEN.ReadAll (0, -1).Count);
                Console.WriteLine ("Usuario con OID " + OIDUsuario + ": " + usuarioCEN.ReadOID (OIDUsuario).Id);
                Console.WriteLine ("Categorias Usuarios totales: " + categoriaUsuarioCEN.ReadAll (0, -1).Count);
                Console.WriteLine ("Categoria Usuario con OID " + OIDCategoria + ": " + categoriaUsuarioCEN.ReadOID (OIDCategoria).Id);

                CategoriaUsuarioCP categoriaUsuarioCP = new CategoriaUsuarioCP ();
                categoriaUsuarioCP.Destroy (OIDCategoria);
                Console.WriteLine ("Usuario con OID " + OIDUsuario + ": " + usuarioCEN.ReadOID (OIDUsuario).Id);
                Console.WriteLine ("Categorias Usuarios totales: " + categoriaUsuarioCEN.ReadAll (0, -1).Count);

                /*PROYECTO*/
                ProyectoCEN proyectoCEN = new ProyectoCEN ();
                Console.WriteLine ("Aqui no llega");
                int OIDProyecto = proyectoCEN.New_ ("APPANIC", "App que te ayuda en la vida", OIDUsuario, null);
                ProyectoCP proyectoCP = new ProyectoCP ();
                Console.WriteLine ("Aqui no llega");
                int OIDProyectoABorrar = proyectoCEN.New_ ("APPANICasdasd", "App que te ayuda en la vida", OIDUsuario, null);

                int aux = usuarioCEN.New_ ("Sergio", "12345", null, "email@gmail.com", "Yupipi93");
                usuarioCEN.CambiarRol (aux, MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum.MiembroHonor);
                List<int> aaux = new List<int>();
                aaux.Add (aux);
                proyectoCP.AgregaParticipantes (OIDProyecto, aaux);
                proyectoCP.AgregaModeradores (OIDProyecto, aaux);
                proyectoCP.EliminaModeradores (OIDProyecto, aaux);
                aaux [0] = usuarioCEN.New_ ("Judith", "12345", null, "judith@gmail.com", "BenhMM");
                proyectoCP.AgregaParticipantes (OIDProyecto, aaux);
                proyectoCP.EliminaParticipantes (OIDProyecto, aaux);
                proyectoCP.Modify (OIDProyecto, "APPPanic", "App que te ayuda en la vida", null);

                proyectoCEN.CambiarEstado (OIDProyecto, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum.EnDesarrollo);
                Console.WriteLine ("Proyectos por estado: " + proyectoCEN.DameProyectosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum.EnDesarrollo).Count);

                Console.WriteLine ("Proyectos usuario pertenece: " + proyectoCEN.DameProyectosUsuarioPertenece (OIDUsuario).Count);

                Console.WriteLine ("Participantes proyecto: " + usuarioCEN.DameParticipantesProyecto (OIDProyecto).Count);
                Console.WriteLine ("Moderadores proyecto: " + usuarioCEN.DameModeradoresProyecto (OIDProyecto).Count);

                Console.WriteLine ("Usuarios: " + usuarioCEN.DameUsuariosPorRol (MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum.Miembro).Count);
                Console.WriteLine ("Miembros de honor: " + usuarioCEN.DameUsuariosPorRol (MultitecUAGenNHibernate.Enumerated.MultitecUA.RolUsuarioEnum.MiembroHonor).Count);


                Console.WriteLine ("Proyecto con OID " + OIDProyecto + ": " + proyectoCEN.ReadOID (OIDProyecto).Id);



                /*CATEGORIA PROYECTO*/
                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN ();

                List<int> listaCategoriasProyecto = new List<int>();

                int OIDCategoriaProyecto = categoriaProyectoCEN.New_ ("Salu");
                categoriaProyectoCEN.Modify (OIDCategoriaProyecto, "Salud");
                listaCategoriasProyecto.Add (OIDCategoriaProyecto);
                OIDCategoriaProyecto = categoriaProyectoCEN.New_ ("Tecnologico");
                listaCategoriasProyecto.Add (OIDCategoriaProyecto);
                OIDCategoriaProyecto = categoriaProyectoCEN.New_ ("Puto Amo2");
                listaCategoriasProyecto.Add (OIDCategoriaProyecto);
                proyectoCEN.AgregaCategoriasProyecto (OIDProyecto, listaCategoriasProyecto);

                listaCategoriasProyecto.RemoveAt (2);
                proyectoCEN.EliminaCategoriasProyecto (OIDProyecto, listaCategoriasProyecto);
                Console.WriteLine ("Proyectos por categoria: " + proyectoCEN.DameProyectosPorCategoria (OIDCategoriaProyecto).Count);

                proyectoCEN.AgregaCategoriasUsuario (OIDProyecto, OIDsCategorias);
                OIDsCategorias.RemoveAt (0);
                proyectoCEN.EliminaCategoriasUsuario (OIDProyecto, OIDsCategorias);

                Console.WriteLine ("Categorias Proyecto totales: " + categoriaProyectoCEN.ReadAll (0, -1).Count);
                Console.WriteLine ("Categoria Proyecto con OID " + OIDCategoriaProyecto + ": " + categoriaProyectoCEN.ReadOID (OIDCategoriaProyecto).Id);

                CategoriaProyectoCP categoriaProyectoCP = new CategoriaProyectoCP ();
                categoriaProyectoCP.Destroy (OIDCategoriaProyecto);



                /*EVENTOS*/
                EventoCEN eventoCEN = new EventoCEN ();
                int OIDEvento = eventoCEN.New_ ("Evento1", "El Mas guay", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null);
                eventoCEN.PublicaEvento (OIDEvento);
                int OIDEventoABorrar = eventoCEN.New_ ("EventoABorrar", "El Mas guay", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null);
                eventoCEN.PublicaEvento (OIDEventoABorrar);
                EventoCP eventoCP = new EventoCP ();
                eventoCEN.AgregaCategorias (OIDEvento, listaCategoriasProyecto);
                listaCategoriasProyecto.RemoveAt (0);
                eventoCEN.EliminaCategorias (OIDEvento, listaCategoriasProyecto);

                List<int> listaEventos = new List<int>();
                listaEventos.Add (OIDEvento);
                listaEventos.Add (OIDEventoABorrar);

                proyectoCP.AgregaEventos (OIDProyecto, listaEventos);
                Console.WriteLine ("Eventos por proyecto: " + eventoCEN.DameEventosPorProyecto (OIDProyecto).Count);

                Console.WriteLine ("Proyectos por evento: " + proyectoCEN.DameProyectosPorEvento (OIDEvento).Count);
                eventoCP.Modify (OIDEvento, "Evento", "El Mas guay", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, null);
                //eventoCP.Destroy (OIDEventoABorrar);

                listaEventos.Remove (OIDEventoABorrar);

                proyectoCP.EliminaEventos (OIDProyecto, listaEventos);

                Console.WriteLine ("Eventos filtrados: " + eventoCEN.DameEventosFiltrados (-1, DateTime.Parse ("01/01/2030"), null).Count);

                Console.WriteLine ("Eventos totales: " + eventoCEN.ReadAll (0, -1).Count);
                Console.WriteLine ("Evento con OID " + OIDEvento + ": " + eventoCEN.ReadOID (OIDEvento).Id);


                /*SOLICITUD*/

                SolicitudCEN solicitudCEN = new SolicitudCEN ();
                int OIDSolicitud = solicitudCEN.New_ (OIDUsuario, OIDProyecto);
                solicitudCEN.Aceptar (OIDSolicitud);
                solicitudCEN.Rechazar (OIDSolicitud);


                int OIDSolicitud2 = solicitudCEN.New_ (OIDUsuario, OIDProyecto);
                solicitudCEN.Aceptar (OIDSolicitud2);

                solicitudCEN.New_ (OIDUsuario, OIDProyecto);

                //Filtros de SOLICITUD
                Console.WriteLine ("DameSolicitudesPorProyectoYEstado: " + solicitudCEN.DameSolicitudesPorProyectoYEstado (OIDProyecto, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum.Aceptada).Count);
                Console.WriteLine ("DameSolicitudesPorUsuarioYEstado: " + solicitudCEN.DameSolicitudesPorUsuarioYEstado (OIDUsuario, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoSolicitudEnum.Aceptada).Count);
                Console.WriteLine ("DameSolicidudesPorUsuarioYProyecto: " + solicitudCEN.DameSolicidudesPorUsuarioYProyecto (OIDProyecto, OIDUsuario).Count);
                Console.WriteLine ("DameSolicitudesPendientesPorProyectoDe: " + solicitudCEN.DameSolicitudesPendientesPorProyectoDeUsuario (OIDProyecto, OIDUsuario).Count);

                solicitudCEN.EnviarSolicitud (OIDSolicitud2);

                solicitudCEN.Destroy (OIDSolicitud);

                Console.WriteLine ("Solicitud con OID " + OIDSolicitud2 + ": " + solicitudCEN.ReadOID (OIDSolicitud2).Id);
                Console.WriteLine ("Solicitudes totales: " + solicitudCEN.ReadAll (0, -1).Count);


                Console.WriteLine ("Proyecto con OID " + OIDProyecto + ": " + proyectoCEN.ReadOID (OIDProyecto).Id);
                proyectoCP.Destroy (OIDProyecto);
                Console.WriteLine ("Proyectos totales: " + proyectoCEN.ReadAll (0, -1).Count);



                /*MENSAJES*/
                MensajeCEN mensajeCEN = new MensajeCEN ();
                int OIDMensaje = mensajeCEN.New_ ("Esto es un mensaje", "Mi primerito mensaje", OIDUsuario, OIDUsuario, null);

                Console.WriteLine ("Mensajes por receptor: " + mensajeCEN.DameMensajesPorReceptor (OIDUsuario).Count);

                Console.WriteLine ("Mensajes por autor: " + mensajeCEN.DameMensajesPorAutor (OIDUsuario).Count);

                mensajeCEN.CambiarEstado (OIDMensaje, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoLecturaEnum.Leido);

                Console.WriteLine ("Mensajes por autor filtrados (Archivados) : " + mensajeCEN.DameMensajesPorAutorFiltrados (OIDUsuario, DateTime.Parse ("01/01/2030"), DateTime.Parse ("01/01/1800"), MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado).Count);
                Console.WriteLine ("Mensajes por receptor filtrados (Archivados) : " + mensajeCEN.DameMensajesPorReceptorFiltrados (OIDUsuario, DateTime.Parse ("01/01/2030"), DateTime.Parse ("01/01/1800"), MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado).Count);

                mensajeCEN.CambiarBandejaAutor (OIDMensaje, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado);
                mensajeCEN.CambiarBandejaReceptor (OIDMensaje, MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado);

                Console.WriteLine ("Mensajes por autor filtrados (Archivados) : " + mensajeCEN.DameMensajesPorAutorFiltrados (OIDUsuario, DateTime.Parse ("01/01/2030"), DateTime.Parse ("01/01/1800"), MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado).Count);
                Console.WriteLine ("Mensajes por receptor filtrados (Archivados) : " + mensajeCEN.DameMensajesPorReceptorFiltrados (OIDUsuario, DateTime.Parse ("01/01/2030"), DateTime.Parse ("01/01/1800"), MultitecUAGenNHibernate.Enumerated.MultitecUA.BandejaMensajeEnum.Archivado).Count);

                mensajeCEN.EnviarMensaje (OIDMensaje);

                Console.WriteLine ("Mensajes totales: " + mensajeCEN.ReadAll (0, -1).Count);
                Console.WriteLine ("Mensajes con OID " + OIDMensaje + ": " + mensajeCEN.ReadOID (OIDMensaje).Id);

                mensajeCEN.Destroy (OIDMensaje);


                /*SERVICIOS*/
                ServicioCEN servicioCEN = new ServicioCEN ();
                int OIDServicio = servicioCEN.New_ ("Hosting", "Servicio de alojamiento web", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible, null);
                servicioCEN.Modify (OIDServicio, "Hosting Ilimitado", "Servicio de alojamiento web sin limites", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible, null);
                OIDServicio = servicioCEN.New_ ("Prueba", "Probando el insertar mas servicios para ver si funciona la fecha", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.NoDisponible, null);
                OIDServicio = servicioCEN.New_ ("Borrar", "Pues... Aqui voy a probar que funcione el destroy", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible, null);
                servicioCEN.Destroy (OIDServicio);
                OIDServicio = servicioCEN.New_ ("Borrar2", "Este realmente se va a quedar", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible, null);
                IList<ServicioEN> listaServicios = servicioCEN.ReadAll (0, -1);
                Console.WriteLine ("**** LISTANDO LOS SERVICIOS");
                foreach (ServicioEN elemento in listaServicios) {
                        Console.WriteLine (elemento.Nombre + " " + elemento.Estado);
                }
                servicioCEN.CambiarDisponibilidad (OIDServicio, MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.NoDisponible);
                listaServicios = servicioCEN.ReadAll (0, -1);
                Console.WriteLine ("**** LISTANDO LOS SERVICIOS");
                foreach (ServicioEN elemento in listaServicios) {
                        Console.WriteLine (elemento.Nombre + " " + elemento.Estado);
                }
                IList<ServicioEN> listaServiciosNoDispo = servicioCEN.DameServiciosPorEstado (MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.NoDisponible);
                Console.WriteLine ("********* SERVICIOS NO DISPONIBLES");
                foreach (ServicioEN elemento in listaServiciosNoDispo) {
                        Console.WriteLine (elemento.Nombre + " " + elemento.Estado);
                }


                /*RECUERDO*/
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN ();
                int OIDRecuerdo = recuerdoCEN.New_ ("Recuerdo1", "esto es un recuerdo", OIDEvento, null);
                recuerdoCEN.Modify (OIDRecuerdo, "Recuerdo", "Esto es un recuerdo modificado", null);
                OIDRecuerdo = recuerdoCEN.New_ ("Recuerdo2", "Este es un segundo recuerdo", OIDEvento, null);
                OIDRecuerdo = recuerdoCEN.New_ ("Recuerdo3", "Haciendo mas recuerdos", OIDEvento, null);
                OIDRecuerdo = recuerdoCEN.New_ ("Recuerdo4", "Otro recuerdo", OIDEvento, null);


                IList<RecuerdoEN> listaRecuerdosFiltro = recuerdoCEN.DameRecuerdosPorProyecto (OIDEvento);
                Console.WriteLine ("**** FILTRO DE RECUERDOS ******");
                foreach (RecuerdoEN elemento in listaRecuerdosFiltro) {
                        Console.WriteLine (elemento.Titulo + ": " + elemento.Cuerpo);
                }

                eventoCP.Destroy (OIDEvento);

                /*NOTICIA*/
                NoticiaCEN noticiaCEN = new NoticiaCEN ();
                int OIDNoticia = noticiaCEN.New_ ("Noticia 1", "cuerpo", null);
                noticiaCEN.Modify (OIDNoticia, "Noticia 1 Modificada", "Noticion informativo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 2", "cuerpo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 3", "cuerpo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 4", "cuerpo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 5", "cuerpo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 6", "cuerpo", null);
                OIDNoticia = noticiaCEN.New_ ("Noticia 7", "cuerpo", null);


                foreach (NoticiaEN noticia in noticiaCEN.DameNUltimasNoticias (4))
                        Console.WriteLine (noticia.Titulo + ": " + noticia.Cuerpo);

                Console.WriteLine (noticiaCEN.ReadAll (0, -1).Count);
                noticiaCEN.ReadOID (OIDNoticia);

                noticiaCEN.Destroy (OIDNoticia);



                /*NOTIFICACION USUARIO*/
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN ();
                Console.WriteLine ("Notificaciones por usuario: " + notificacionUsuarioCEN.DameNotificacionesPorUsuario (OIDUsuario).Count);
                Console.WriteLine ("Notificaciones no leidas por usuario: " + notificacionUsuarioCEN.DameNotificacionesNoLeidasPorUsuario (OIDUsuario).Count);
                notificacionUsuarioCEN.LeerNotificacion (notificacionUsuarioCEN.DameNotificacionesPorUsuario (OIDUsuario) [0].Id);
                Console.WriteLine ("Notificaciones no leidas por usuario: " + notificacionUsuarioCEN.DameNotificacionesNoLeidasPorUsuario (OIDUsuario).Count);



                Console.WriteLine ("Todo ha ido bien");
                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
