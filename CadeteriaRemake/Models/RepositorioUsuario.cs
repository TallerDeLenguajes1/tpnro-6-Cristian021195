using CadeteriaRemake.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.Models
{
    public class RepositorioUsuario
    {
        public Usuario obtenerUsuario(Usuario usuario)
        {
            Usuario user = new Usuario();
            string consulta = "SELECT COUNT(*) as cantidad, id_usuario, nombre_usuario, contra, tipo FROM usuarios WHERE nombre_usuario = @nombre_usuario";

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
                    int cantidad = 0; bool res = false;
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"{consulta}", connection);                    
                    cmd.Parameters.AddWithValue("@nombre_usuario", usuario.Nombre_usuario);
                    cmd.Parameters.AddWithValue("@contra", usuario.Contra);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cantidad = reader.GetInt32("cantidad");
                            if (cantidad == 1)
                            {
                                user.Nombre_usuario = reader.GetString("nombre_usuario");
                                user.Tipo = reader.GetString("tipo");
                                user.Id_usuario = reader.GetInt32("id_usuario");
                                user.Contra = reader.GetString("contra");
                            }
                            else
                            {
                                user.Contra = BCrypt.Net.BCrypt.HashPassword("error");
                            }
                        }
                    }
                    return user;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return user;
                }
            }
        }
    }
}
