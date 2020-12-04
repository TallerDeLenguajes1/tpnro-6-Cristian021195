using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaRemake.Entidades
{
    public class Usuario
    {
        private int id_usuario;
        private string nombre_usuario;
        private string contra;
        private string tipo;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
