using System;
using System.Collections.Generic;
using System.Text;

namespace CadeteriaRemake.Entidades
{
    public class Cadete: Persona
    {
        //public List<Pedido> pedidos = new List<Pedido>();
        private List<Pedido> pedidos = new List<Pedido>();
        private string vehiculo;

        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
        public string Vehiculo { get => vehiculo; set => vehiculo = value; }

        public override string Presertarse()
        {
            return "Hola soy un Cadete!";
        }
    }
}
