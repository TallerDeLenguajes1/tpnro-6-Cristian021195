using CadeteriaRemake.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.ViewModels
{
    public class CadeteViewModel
    {
        public string Id;
        public string Nombre;
        public string Direccion;
        public string Telefono;
        public int Estado;
        public List<Pedido> pedidos = new List<Pedido>();
        public string Vehiculo;
    }
}
