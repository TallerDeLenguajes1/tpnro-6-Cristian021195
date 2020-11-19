using CadeteriaRemake.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteriaRemake.Models
{
    public class RepositorioCliente
    {
        public List<Cliente> obtenerClientes(int estado)
        {
            List<Cliente> clientes = new List<Cliente>();
            string consulta = "";
            if (estado == 1)
            {
                consulta = "SELECT id_cliente ,nombre, direccion, telefono FROM clientes WHERE estado = @estado";
            }
            else
            {
                consulta = "SELECT id_cliente ,nombre, direccion, telefono FROM clientes ";
            }

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "cadeteria",
                UserID = "root",
                Password = "",
                Port = 3306,
            };
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            //using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"{consulta}", connection);
                    if (estado == 1)
                    {
                        cmd.Parameters.AddWithValue("@estado", estado);
                    }
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
                    return clientes;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return clientes;
                }
            }
        }
        public bool altaCliente(Cliente cliente)
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
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO clientes (nombre, direccion, telefono, vehiculo, estado) VALUES ('{cliente.Nombre}','{cliente.Direccion}','{cliente.Telefono}', '1')", connection);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();

                    //return Redirect("~/Cliente");
                    return true;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return false;
                }
            }
        }

        public bool eliminarCliente(string id)
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
                    return true;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return true;
                }
            }

        }

        public Cliente obtenerCliente(string id)
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
                    MySqlCommand cmd = new MySqlCommand($"SELECT id_cliente ,nombre, direccion, telefono, estado FROM clientes WHERE id_cliente = '{id}'", connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Cliente cliente = new Cliente();
                        while (reader.Read())
                        {
                            cliente.Id = reader.GetString("id_cliente");
                            cliente.Nombre = reader.GetString("nombre");
                            cliente.Direccion = reader.GetString("direccion");
                            cliente.Telefono = reader.GetString("telefono");
                            cliente.Estado = reader.GetInt32("estado");
                        }
                        return cliente;
                    }
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return null;
                }
            }
        }

        public bool modificacionCliente(Cliente cliente)
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
                    connection.Close(); //return View(cliente);
                    return true;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return false;
                }
            }
        }
    }
}
