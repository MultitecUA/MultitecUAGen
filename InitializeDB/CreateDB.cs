
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MultitecUAGenNHibernate.CP.MultitecUA;
using MultitecUAGenNHibernate.EN.MultitecUA;
using MultitecUAGenNHibernate.CEN.MultitecUA;
using MultitecUAGenNHibernate.CAD.MultitecUA;

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
        SqlConnection cnn = new SqlConnection (@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

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
                AdministradorCEN administradorCEN = new AdministradorCEN ();
                int OIDAdministrador = administradorCEN.New_ ("Victor", "12345", "nedyar@hotmail.es", "Nedyar", null);

                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int OIDUsuario = usuarioCEN.New_ ("Judith", "12345", null, "judith@gmail.com", "BenhMM");

                //usuarioCEN.ReadAll(); QUe ostias me pide de argumentos? Preguntar


                CategoriaUsuarioCEN categoriaUsuarioCEN = new CategoriaUsuarioCEN();

                List<int> OIDsCategorias = new List<int>();
                int OIDCategoria = categoriaUsuarioCEN.New_("Programador");
                OIDsCategorias.Add(OIDCategoria);
                OIDCategoria = categoriaUsuarioCEN.New_("Dise�ador");
                OIDsCategorias.Add(OIDCategoria);
                OIDCategoria = categoriaUsuarioCEN.New_("Puto Amo");
                OIDsCategorias.Add(OIDCategoria);

                UsuarioCAD usuarioCAD = new UsuarioCAD();
                usuarioCAD.AgregaCategorias(OIDAdministrador, OIDsCategorias);

                OIDsCategorias.RemoveAt(2);
                usuarioCAD.EliminaCategorias(OIDAdministrador, OIDsCategorias);

                //System.Console.WriteLine(usuarioCEN.DameUsuariosPorCategoria(OIDCategoria));
                /*
                MensajeCP mensajeCP = new MensajeCP ();
                MensajeEN mensajeEN = new MensajeEN();
                mensajeEN = mensajeCP.New_ ("Esto es un mensaje", "Mi primerito mensaje", OIDUsuario, OIDAdministrador, null);
                 */

                /*SERVICIOS*/
                ServicioCEN servicioCEN = new ServicioCEN();
                int OIDServicio = servicioCEN.New_("Hosting","Servicio de alojamiento web",MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible,null);
                servicioCEN.Modify(OIDServicio, "Hosting Ilimitado", "Servicio de alojamiento web sin limites", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoServicioEnum.Disponible, null);

                /*PROYECTO*/
                ProyectoCEN proyectoCEN = new ProyectoCEN();
                int OIDProyecto = proyectoCEN.New_("APPANIC", "App que te ayuda en la vida", MultitecUAGenNHibernate.Enumerated.MultitecUA.EstadoProyectoEnum.Propuesto, OIDUsuario, null);
                //PORQUE PROYECTO NO REQUIERE ADMINISTRADOR??

                /*NOTIFICACION*/
                NotificacionCEN notificacionCEN = new NotificacionCEN();
                int OIDNotificacion = notificacionCEN.New_("Notificacion1", "esto es una notificacion");

                /*NOTIFICACION PROYECTO*/
                NotificacionProyectoCEN notificacionProyectoCEN = new NotificacionProyectoCEN();
                int OIDNotificacionProyecto = notificacionProyectoCEN.New_("NotificacionProyecto1", "mensaje", OIDProyecto);

                /*NOTIFICACION USUARIO*/
                NotificacionUsuarioCEN notificacionUsuarioCEN = new NotificacionUsuarioCEN();
                int OIDNotificacionUsuario = notificacionUsuarioCEN.New_(OIDUsuario, OIDNotificacion);


                /*SOLICITUD*/
                SolicitudCP solicitudCP = new SolicitudCP();
                SolicitudEN solicitudEN = new SolicitudEN();
                solicitudEN = solicitudCP.New_(OIDUsuario, OIDProyecto);

                /*NOTIFICACION SOLICITUD*/
                NotificacionSolicitudCEN notificacionSolicitudCEN = new NotificacionSolicitudCEN();
                int OIDNotificacionSolicitud = notificacionSolicitudCEN.New_("NotificacionProyecto1", "mensaje", solicitudEN.Id);

                /*EVENTOS*/
                EventoCP eventoCP = new EventoCP();
                EventoEN eventoEN = new EventoEN();              
                eventoEN = eventoCP.New_("Evento1","El Mas guay",DateTime.Now,DateTime.Now, DateTime.Now, DateTime.Now, null);

                /*NOTIFICACION EVENTO*/
                NotificacionEventoCEN notificacionEventoCEN = new NotificacionEventoCEN();
                int OIDNotificacionEvento = notificacionEventoCEN.New_("NotificacionEvento1", "mensaje loco de evento", eventoEN.Id);

                /*RECUERDO*/
                RecuerdoCEN recuerdoCEN = new RecuerdoCEN();
                int OIDRecuerdo = recuerdoCEN.New_("Recuerdo1", "esto es un recuerdo", eventoEN.Id, null);

                /*CATEGORIA PROYECTO*/

                CategoriaProyectoCEN categoriaProyectoCEN = new CategoriaProyectoCEN();

                List<int> OIDsCategoriasProyecto = new List<int>();
                int OIDCategoriaProyecto = categoriaProyectoCEN.New_("Salud");
                OIDsCategoriasProyecto.Add(OIDCategoriaProyecto);
                OIDCategoriaProyecto = categoriaProyectoCEN.New_("Tecnologico");
                OIDsCategoriasProyecto.Add(OIDCategoriaProyecto);
                OIDCategoriaProyecto = categoriaProyectoCEN.New_("Puto Amo2");
                OIDsCategoriasProyecto.Add(OIDCategoriaProyecto);


                ProyectoCAD proyectoCAD = new ProyectoCAD();
                proyectoCAD.AgregaCategoriasProyecto(OIDProyecto, OIDsCategoriasProyecto);
                    


                System.Console.WriteLine ("Todo ha ido bien");

                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");



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
