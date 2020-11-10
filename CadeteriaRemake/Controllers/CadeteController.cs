using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaRemake.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CadeteriaRemake.Controllers
{
    public class CadeteController : Controller
    {
        // GET: CadeteController
        
        public ActionResult Index()
        {
            List<Cadete> cadetes = new List<Cadete>();

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cadete ,nombre, direccion, telefono, vehiculo FROM cadetes WHERE estado = '1'", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cadete aux = new Cadete();
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            aux.Vehiculo = reader.GetString("vehiculo");
                            cadetes.Add(aux);
                        }
                    }
                    return View(cadetes);
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }

            /*MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };

            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string res = "conecto!";
                    connection.Close();
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                }
            }*/
            return View();//ADO .NET mysql + net core
        }


        [HttpPost]
        public ActionResult AltaCadete(Cadete cadete)
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO cadetes (nombre, direccion, telefono, vehiculo, estado) VALUES ('{cadete.Nombre}','{cadete.Direccion}','{cadete.Telefono}','{cadete.Vehiculo}', '1')", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    //return View(cadete);
                    return Redirect("~/Cadete");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
            //llego un cadete
            

        }
        public ActionResult BajaCadete()
        {
            List<Cadete> cadetes = new List<Cadete>();

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cadete ,nombre, direccion, telefono, vehiculo FROM cadetes", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cadete aux = new Cadete();
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            aux.Vehiculo= reader.GetString("vehiculo");

                            cadetes.Add(aux);
                        }
                    }
                    return View(cadetes);
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult EliminarCadete(string id) {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"DELETE FROM cadetes WHERE id_cadete = '{id}'", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    return Redirect("~/Cadete");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return Redirect("~/Cadete");
                }
            }
        }


        [HttpPost]
        public ActionResult ModificacionCadete(Cadete cadete)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"UPDATE cadetes SET nombre = '{cadete.Nombre}', direccion = '{cadete.Direccion}', telefono= '{cadete.Telefono}', vehiculo= '{cadete.Vehiculo}', estado= '{cadete.Estado}' WHERE id_cadete = '{cadete.Id}'", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    //return View(cadete);
                    return Redirect("~/Cadete");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
            
        }

        public ActionResult AgregarCadete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerCadete(string id)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cadete ,nombre, direccion, telefono, vehiculo, estado FROM cadetes WHERE id_cadete = '{id}'", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Cadete aux = new Cadete();
                        while (reader.Read())
                        {                            
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            aux.Vehiculo = reader.GetString("vehiculo");
                            aux.Estado = reader.GetInt32("estado");
                        }
                        return View(aux);
                    }
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
        }
    }
}
