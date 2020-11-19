using CadeteriaRemake.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.ViewModels
{
    public class AltaPedidoViewModel
    {
        public string numero;//autoincremental desde ddbb
        public string observacion;
        public tipo_pedido tipoPedido;
        public bool estado_pedido;//se carga por defecto en pendiente
        public bool cupon;
        public List<SelectListItem> cadetes;
        public List<SelectListItem> clientes;
        public int ClienteId { get; set; }
        public int CadeteId { get; set; }
    }
}
