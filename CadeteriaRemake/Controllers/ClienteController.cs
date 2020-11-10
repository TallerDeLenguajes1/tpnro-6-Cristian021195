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
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public ActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();

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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cliente ,nombre, direccion, telefono FROM clientes WHERE estado = '1'", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente aux = new Cliente();
                            aux.Id = reader.GetString("id_cliente");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            clientes.Add(aux);
                        }
                    }
                    return View(clientes);
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaCliente(Cliente cliente)
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
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO clientes (nombre, direccion, telefono, estado) VALUES ('{cliente.Nombre}','{cliente.Direccion}','{cliente.Telefono}', '1')", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    //return View(cadete);
                    return Redirect("~/Cliente");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }//llego un cadete
        }
        public ActionResult BajaModificacion()
        {
            List<Cliente> clientes = new List<Cliente>();

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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cliente ,nombre, direccion, telefono FROM clientes", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente aux = new Cliente();
                            aux.Id = reader.GetString("id_cliente");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            clientes.Add(aux);
                        }
                    }
                    return View(clientes);
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult EliminarCliente(string id)
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
                    MySqlCommand cmd = new MySqlCommand($"DELETE FROM clientes WHERE id_cliente = '{id}'", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    return Redirect("~/Cliente");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return Redirect("~/Cliente");
                }
            }
        }

        [HttpPost]
        public ActionResult ModificacionCliente(Cliente cliente)
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
                    MySqlCommand cmd = new MySqlCommand($"UPDATE clientes SET nombre = '{cliente.Nombre}', direccion = '{cliente.Direccion}', telefono= '{cliente.Telefono}', estado= '{cliente.Estado}' WHERE id_cliente = '{cliente.Id}'", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    //return View(cadete);
                    return Redirect("~/Cliente");
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return Redirect("~/Cliente");
                }
            }
        }

        [HttpPost]
        public ActionResult ObtenerCliente(string id)
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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cliente ,nombre, direccion, telefono, estado FROM clientes WHERE id_cliente = '{id}'", connection);//WHERE id_cliente = '{id}'
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Cliente aux = new Cliente();
                        while (reader.Read())
                        {
                            aux.Id = reader.GetString("id_cliente");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            aux.Estado = reader.GetInt32("estado");
                        }
                        return View(aux);
                    }
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return Redirect("~/Cliente");
                }
            }
        }
    }
}
