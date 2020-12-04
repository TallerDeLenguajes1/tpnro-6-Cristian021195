
using CadeteriaRemake.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.ViewModels
{
    public class EditarPedidoViewModel
    {
        [Display(Description = "Observacion")]
        public string numero { get; set; }
        public string observacion { get; set; }
        public tipo_pedido tipoPedido;
        public bool estado_pedido;
        public bool cupon;
        public List<SelectListItem> cadetes;
        public int ClienteId { get; set; }
        public int CadeteId { get; set; }
    }
}
