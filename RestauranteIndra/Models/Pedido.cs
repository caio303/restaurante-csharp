﻿namespace RestauranteIndra.Models
{
    internal class Pedido
    {
        private int IdPrato = 1;
        public List<Prato> Pratos { get; private set; }
        private readonly DateTime DataDeEmissao;

        public Pedido()
        {
            DataDeEmissao = DateTime.Today;
            Pratos = new List<Prato>();
        }

        public void AdicionarPrato(Prato prato)
        {
            prato.Id = IdPrato++;
            Pratos.Add(prato);
        }

        public double CalcularPrecoTotalComOuSemPromocao()
        {
            double precoTotal = 0;
            
            int indiceDoPrato = 0;

            if(DataDeEmissao.DayOfWeek == DayOfWeek.Tuesday)
            {
                foreach (var prato in Pratos)
                {
                    precoTotal += indiceDoPrato == 2? (prato.Preco * 0.5) : prato.Preco;
                    indiceDoPrato++;
                }
            }else{
                foreach (var prato in Pratos)
                {
                    precoTotal += prato.Preco;
                }
            }


            return precoTotal;
        }

        public void ZerarPedido()
        {
            Pratos.Clear();
        }

        public override string ToString()
        {
            string toString = "";

            foreach(var prato in Pratos)
            {
                toString += prato.ToString(IdPrato) + "\n";
            }

            if (DataDeEmissao.DayOfWeek == DayOfWeek.Tuesday)
            {
                toString += "Promoção de Terça-Feira: -50% no terceiro prato!\n\n";
                toString += string.Format("Valor Final com Desconto: {0:C2}\n",CalcularPrecoTotalComOuSemPromocao());
            }else
            {
                toString += string.Format("\nValor Total do Pedido: {0:C2}\n\n", CalcularPrecoTotalComOuSemPromocao());
                toString += "Temos Promoção na Terça-Feira! Terceiro prato com 50% de desconto!";
            }

            return toString;
        }
    }
}
