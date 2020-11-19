using CadeteriaRemake.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.Models
{
    public class RepositorioPedido
    {
        public List<Pedido> obtenerPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();
            string consulta = "SELECT numero_pedido, observacion, tipo_pedido, pedidos.estado, cupon, clientes.nombre as cliente, cadetes.nombre as cadete FROM pedidos INNER JOIN clientes ON pedidos.fid_cliente = clientes.id_cliente INNER JOIN cadetes ON pedidos.fid_cadete = cadetes.id_cadete;";

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
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.Nombre = reader.GetString("cliente");

                            Cadete cadete = new Cadete();
                            cadete.Nombre = reader.GetString("cadete");

                            Pedido aux = new Pedido(cliente);
                            aux.Numero = reader.GetString("numero_pedido");
                            aux.Observacion = reader.GetString("observacion");
                            aux.TipoPedido = (CadeteriaRemake.Entidades.tipo_pedido)Enum.Parse(typeof(CadeteriaRemake.Entidades.tipo_pedido), reader.GetString("tipo_pedido"));
                            //aux.TipoPedido = reader.GetString("tipo_pedido");
                            if (reader.GetInt32("estado") == 1)
                            {
                                aux.Estado_pedido = true;
                            }
                            else
                            {
                                aux.Estado_pedido = false;
                            }
                            if (reader.GetInt32("cupon") == 1)
                            {
                                aux.Cupon = true;
                            }
                            else
                            {
                                aux.Cupon = false;
                            }
                            aux.Cadete = cadete;//¿?
                            pedidos.Add(aux);

                        }
                    }
                    return pedidos;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return pedidos;
                }
            }
        }
    }
}
