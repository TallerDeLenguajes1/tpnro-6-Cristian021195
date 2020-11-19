using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaRemake.Entidades;
using CadeteriaRemake.ViewModels;

namespace CadeteriaRemake.ViewModels
{
    public class PedidoViewModel
    {
        public string numero;
        public string observacion;
        public tipo_pedido tipoPedido;
        public bool estado_pedido;
        public bool cupon;
        public Cliente cliente;
        public Cadete cadete;
        public double costo;
    }
}
