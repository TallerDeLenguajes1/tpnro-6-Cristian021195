using CadeteriaRemake.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.ViewModels
{
    public class AltaPedidoViewModel
    {
        public string numero;//autoincremental desde ddbb

        [Display(Description = "Observacion")]
        public string observacion { get; set; }
        public tipo_pedido tipoPedido;
        public bool estado_pedido = true;//se carga por defecto en pendiente
        public bool cupon { get; set; }
        public List<SelectListItem> cadetes;
        public List<SelectListItem> clientes;
        public int ClienteId { get; set; }
        public int CadeteId { get; set; }
        public double jornal()
        {
            double estandar = 150;
            if (cupon)
            {
                estandar = estandar * 0.9;
            }

            if (tipo_pedido.dedicado == tipoPedido)
            {
                estandar = estandar * 1.3;
            }
            else if (tipo_pedido.ecologico == tipoPedido)
            {
                estandar = estandar * 1.05;
            }
            else if (tipo_pedido.expres == tipoPedido)
            {
                estandar = estandar * 1.25;
            }

            return estandar;
        }
    }
}
