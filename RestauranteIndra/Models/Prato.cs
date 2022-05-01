namespace RestauranteIndra.Models
{
    internal class Prato
    {
        public int Id { get; set; }
        public string Foto { get; private set; }
        public string Nome { get; private set; }
        public List<Ingrediente> Ingredientes { get; private set; }
        public double Preco { get; set; }

        public Prato(string nome, string foto)
        {
            Foto = foto;
            Nome = nome;
            Ingredientes = new List<Ingrediente>();
            Preco = 0;
            Id = 0;
        }

        public void AdicionarIngrediente(Ingrediente ingd)
        {
            if (ingd.PesoEmGramas != null)
            {
                if (ingd.PesoEmGramas > 230) Preco += 8.5;
                else Preco += 4.99;

            }else if(ingd.VolumeEmMililitros != null)
            {
                if (ingd.VolumeEmMililitros > 180) Preco += 8.5;
                else Preco += 4.99;
            }
            Ingredientes.Add(ingd);
        }

        public int CalcularPesoEmGramasOuML()
        {
            int pesoTotal = 0;
            foreach (var ingrediente in Ingredientes)
            {
                if (ingrediente.PesoEmGramas != null)
                {
                    pesoTotal += (int) ingrediente.PesoEmGramas;
                }else if(ingrediente.VolumeEmMililitros != null) {
                    pesoTotal += (int) ingrediente.VolumeEmMililitros;
                }
            }
            return pesoTotal;
        }

        public Prato Clonar()
        {
            return (Prato) MemberwiseClone();
        }

        public string ToString(int id)
        {
            string toString = "";

            toString += string.Format("{0}\n",Foto);

            toString += string.Format(" {0}- {1}\n",Id,Nome);

            foreach(var ingrediente in Ingredientes)
            {
                toString += "  ";
                toString += ingrediente.ToString();
            }

            toString += string.Format(" Total: {0:C2} - Peso: ", Preco);
            if (!Ingredientes.Any(x => x.EhLiquido.Equals(false)))
            {
                toString += string.Format("{0} mL\n", CalcularPesoEmGramasOuML());
            }
            else
            {
                toString += string.Format("{0} gramas\n", CalcularPesoEmGramasOuML());
            }

            return toString;
        }
    }
}
