using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteIndra.Models
{
    internal class Promocao
    {

        public double DescontarPrecoFinal(Pedido pedidoFinal)
        {
            double desconto = 0;
            if(pedidoFinal.Pratos.Count > 2)
            {
                desconto = pedidoFinal.Pratos[2].Preco * 0.5;
            }
            
            return pedidoFinal.CalcularPrecoTotal() - desconto;

        }

    }
}
