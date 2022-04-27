namespace RestauranteIndra.Models
{
    internal class Pedido
    {
        private int IdPrato = 1;
        public List<Prato> Pratos { get; private set; }

        public Promocao? Promocao { get; private set; }

        public Pedido(Promocao promocao)
        {
            Pratos = new List<Prato>();
            Promocao = promocao;
        }
        public Pedido()
        {
            Pratos = new List<Prato>();
            Promocao = null;
        }

        public void AdicionarPrato(Prato prato)
        {
            prato.Id = IdPrato++;
            Pratos.Add(prato);
        }

        public double CalcularPrecoTotal()
        {
            double precoTotal = 0;

            foreach (var prato in Pratos)
            {
                precoTotal += prato.CalcularPreco();
            }

            return precoTotal;
        }

        public void ZerarPedido()
        {
            Pratos.Clear();
        }

        public void AdicionarPromocao(Promocao promocao)
        {
            Promocao = promocao;
        }

        public override string ToString()
        {
            string toString = "";

            foreach(var prato in Pratos)
            {
                toString += prato.ToString(IdPrato) + "\n";
            }

            return toString;
        }
    }
}
