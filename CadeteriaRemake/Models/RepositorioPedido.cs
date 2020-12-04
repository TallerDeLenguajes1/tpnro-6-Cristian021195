using AutoMapper;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.Models
{
    public class RepositorioPedido
    {
        public List<PedidoViewModel> obtenerInforme()
        {
            List<PedidoViewModel> pedidos = new List<PedidoViewModel>();
            string consulta = "SELECT cadetes.nombre as cadete, SUM(jornal) as jornal FROM pedidos INNER JOIN clientes ON pedidos.fid_cliente = clientes.id_cliente INNER JOIN cadetes ON pedidos.fid_cadete = cadetes.id_cadete GROUP BY cadete;";

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
                            Cadete cad = new Cadete();
                            cad.Nombre = reader.GetString("cadete");
                            PedidoViewModel aux = new PedidoViewModel();
                            aux.cliente = new Cliente(); aux.cadete = cad;
                            aux.costo = reader.GetDouble("jornal");
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
                            aux.Cadete = cadete;
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

        public bool eliminarPedido(string id)
        {
            string consulta = "DELETE FROM pedidos WHERE numero_pedido = @numero_pedido;";
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
                    MySqlCommand cmd = new MySqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@numero_pedido", id);
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
        public EditarPedidoViewModel obtenerPedido(string id)
        {
            string consulta = "SELECT * FROM pedidos WHERE numero_pedido = @numero_pedido;";

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
                EditarPedidoViewModel pedido = new EditarPedidoViewModel();
                RepositorioCadete repoCadete = new RepositorioCadete();
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand($"{consulta}", connection);
                    cmd.Parameters.AddWithValue("@numero_pedido", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pedido.numero = reader.GetString("numero_pedido");
                            pedido.observacion= reader.GetString("observacion");
                            pedido.tipoPedido = (CadeteriaRemake.Entidades.tipo_pedido)Enum.Parse(typeof(CadeteriaRemake.Entidades.tipo_pedido), reader.GetString("tipo_pedido"));
                            if (reader.GetInt32("estado") == 1)
                            {
                                pedido.estado_pedido = true;
                            }
                            else
                            {
                                pedido.estado_pedido = false;
                            }
                            if (reader.GetInt32("cupon") == 1)
                            {
                                pedido.cupon = true;
                            }
                            else
                            {
                                pedido.cupon = false;
                            }
                            pedido.ClienteId = reader.GetInt32("fid_cliente");
                        }
                    }
                    return pedido;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return pedido;
                }
            }
        }
        public bool editarPedido(EditarPedidoViewModel pedido)
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
                    MySqlCommand cmd = new MySqlCommand("UPDATE pedidos SET observacion = @observacion, tipo_pedido = @tipo_pedido, estado = @estado, cupon = @cupon, fid_cadete = @cadete WHERE numero_pedido = @numero;", connection);
                    cmd.Parameters.AddWithValue("@estado", pedido.estado_pedido);
                    if (pedido.observacion == null)
                    {
                        cmd.Parameters.AddWithValue("@observacion", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@observacion", pedido.observacion);
                    }
                    cmd.Parameters.AddWithValue("@tipo_pedido", pedido.tipoPedido);
                    cmd.Parameters.AddWithValue("@cupon", pedido.cupon);
                    cmd.Parameters.AddWithValue("@cadete", pedido.CadeteId);
                    cmd.Parameters.AddWithValue("@numero", pedido.numero);
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception exception)
                {
                    string resp = exception.Message;
                    return false;
                }
            }
        }
        public bool altaPedido(AltaPedidoViewModel pedido)
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
                    MySqlCommand cmd = new MySqlCommand($"INSERT INTO pedidos (observacion, tipo_pedido, estado, cupon, fid_cliente, fid_cadete, jornal) VALUES (@observacion, @tipo_pedido, 0, @cupon, @fid_cliente, @fid_cadete, @jornal);", connection);
                    cmd.Parameters.AddWithValue("@estado", pedido.estado_pedido);
                    if (pedido.observacion == null)
                    {
                        cmd.Parameters.AddWithValue("@observacion", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@observacion", pedido.observacion);
                    }
                    cmd.Parameters.AddWithValue("@tipo_pedido", pedido.tipoPedido);
                    cmd.Parameters.AddWithValue("@cupon", pedido.cupon);
                    cmd.Parameters.AddWithValue("@fid_cadete", pedido.CadeteId);
                    cmd.Parameters.AddWithValue("@fid_cliente", pedido.ClienteId);
                    cmd.Parameters.AddWithValue("@jornal", pedido.jornal());
                    var res = cmd.ExecuteNonQuery();
                    connection.Close();
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
