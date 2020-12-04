using CadeteriaRemake.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaRemake.Models;

namespace CadeteriaRemake.Models
{
    public class RepositorioCadete
    {
        public List<Cadete> obtenerCadetes(int estado)
        {
            List<Cadete> cadetes = new List<Cadete>();
            string consulta = "";
            if (estado == 1)
            {
                consulta = "SELECT id_cadete ,nombre, direccion, telefono, vehiculo FROM cadetes WHERE estado = @estado";
            }
            else
            {
                consulta = "SELECT id_cadete ,nombre, direccion, telefono, vehiculo FROM cadetes";
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
                            Cadete aux = new Cadete();
                            aux.Id = reader.GetString("id_cadete");
                            aux.Nombre = reader.GetString("nombre");
                            aux.Direccion = reader.GetString("direccion");
                            aux.Telefono = reader.GetString("telefono");
                            aux.Vehiculo = reader.GetString("vehiculo");
                            cadetes.Add(aux);
                        }
                    }
                    return cadetes;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return cadetes;
                }
            }
        }
        public bool altaCadete(Cadete cadete)
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
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO cadetes (nombre, direccion, telefono, vehiculo, estado) VALUES (@nombre, @direccion, @telefono, @vehiculo, @estado)", connection);
                    cmd.Parameters.AddWithValue("@nombre", cadete.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", cadete.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", cadete.Telefono);
                    cmd.Parameters.AddWithValue("@vehiculo", cadete.Vehiculo);
                    cmd.Parameters.AddWithValue("@estado", 1);
                    
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();

                    //return Redirect("~/Cadete");
                    return true;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return false;
                }
            }
        }

        public bool eliminarCadete(string id)
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
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM cadetes WHERE id_cadete = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public Cadete obtenerCadete(string id)
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
                    MySqlCommand cmd = new MySqlCommand("SELECT id_cadete ,nombre, direccion, telefono, vehiculo, estado FROM cadetes WHERE id_cadete = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Cadete cadete = new Cadete();
                        while (reader.Read())
                        {
                            cadete.Id = reader.GetString("id_cadete");
                            cadete.Nombre = reader.GetString("nombre");
                            cadete.Direccion = reader.GetString("direccion");
                            cadete.Telefono = reader.GetString("telefono");
                            cadete.Vehiculo = reader.GetString("vehiculo");
                            cadete.Estado = reader.GetInt32("estado");
                        }
                        return cadete;
                    }
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return null;
                }
            }
        }

        public bool modificacionCadete(Cadete cadete)
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
                    connection.Close(); //return View(cadete);
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
