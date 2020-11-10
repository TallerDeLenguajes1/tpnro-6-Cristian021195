using System;
using System.Collections.Generic;
using System.Text;

namespace CadeteriaRemake.Entidades
{
    class Cadeteria
    {
        private string nombre;
        private List<Cadete> cadetes;

        public Cadeteria(string nombre)
        {
            this.Nombre = nombre;
            this.Cadetes = new List<Cadete>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

        public void informeSimple(List<Cadete> Cadetes) {
            int entregados = 0;
            double jornal = 0;
            foreach (Cadete e in Cadetes) {
                Console.WriteLine("CADETE: {0} ({1}):", e.Nombre, e.Id);
                foreach (Pedido p in e.Pedidos) {
                    if (p.Estado_pedido) {
                        entregados++;
                        jornal += p.costo();
                    }
                }
                Console.WriteLine("\tPEDIDOS ENTREGADOS: {0}, JORNAL: {1}\n", entregados, jornal);
                entregados = 0; jornal = 0;
            }
        }
        public List<Cadete> empleadoDelDia(List<Cadete> Cadetes) {
            List<Cadete> empDelDia = new List<Cadete>();
            int entregados = 0; int may = 0;
            foreach (Cadete e in Cadetes)
            {
                foreach (Pedido p in e.Pedidos)
                {
                    if (p.Estado_pedido)
                    {
                        entregados++;
                    }
                }
                if (may < entregados) {
                    may = entregados;
                }
                entregados = 0;
            }
            foreach (Cadete e in Cadetes)
            {
                foreach (Pedido p in e.Pedidos)
                {
                    if (p.Estado_pedido)
                    {
                        entregados++;
                    }
                }
                if (may == entregados)
                {
                    empDelDia.Add(e);
                }
                entregados = 0;
            }
            return empDelDia;
        }
        public double promedioEntregados(List<Cadete> Cadetes) {
            double entregados = 0; double cant = 0;

            foreach (Cadete e in Cadetes)
            {
                foreach (Pedido p in e.Pedidos)
                {
                    if (p.Estado_pedido)
                    {
                        entregados++;
                    }
                    cant++;
                }
            }

            return cant/entregados;
        }
    }
}
