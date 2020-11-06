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
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO cadetes (nombre, direccion, telefono) VALUES ('{cadete.Nombre}','{cadete.Direccion}','{cadete.Telefono}')", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    return View(cadete);
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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cadete ,nombre, direccion, telefono FROM cadetes", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cadete aux = new Cadete();
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");

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
        public void EliminarCadete(string id) {

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
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                }
            }

        }
        public ActionResult ModificacionCadete()
        {
            return View();
        }

        public ActionResult ListadoCadete()
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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cadete ,nombre, direccion, telefono FROM cadetes", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cadete aux = new Cadete();
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");

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


            return View();
        }
    }
}
