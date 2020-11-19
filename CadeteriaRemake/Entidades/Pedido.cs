using System;
using System.Collections.Generic;
using System.Text;

namespace CadeteriaRemake.Entidades
{
    public enum tipo_pedido
    {
        expres,
        dedicado,
        ecologico
    }
    public class Pedido
    {
        //private Random rand = new Random();
        private string numero;
        private string observacion;
        private tipo_pedido tipoPedido;
        private bool estado_pedido;
        private bool cupon;
        private Cliente cliente;
        private Cadete cadete;

        public Pedido(Cliente cliente) {//composicion
            this.cliente = cliente;
        }

        public string Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public tipo_pedido TipoPedido { get => tipoPedido; set => tipoPedido = value; }
        public bool Estado_pedido { get => estado_pedido; set => estado_pedido = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public bool Cupon { get => cupon; set => cupon = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public double costo() {
            double estandar = 150;
            if (Cupon) {
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
