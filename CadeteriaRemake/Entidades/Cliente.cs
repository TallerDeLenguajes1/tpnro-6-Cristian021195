using System;
using System.Collections.Generic;
using System.Text;

namespace CadeteriaRemake.Entidades
{
    public class Cliente: Persona
    {

        public override string Presertarse() {//polimorfismo
            return "Hola soy un Cliente y quiero mi pedido!";
        }
    }
    
}
