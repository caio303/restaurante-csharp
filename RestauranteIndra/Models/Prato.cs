﻿namespace RestauranteIndra.Models
{
    internal class Prato
    {
        public int? Id { get; set; }
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
            Id = null;
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

        public int CalcularPesoEmGramas()
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

        public double CalcularPreco()
        {
            return Preco;
        }

        public string ToString(int id)
        {
            string toString = "";

            toString += String.Format("{0}\n",Foto);

            if(Id == null) toString += String.Format(" # {0}\n",Nome);
            else toString += String.Format(" {0}- {1}\n",Id,Nome);

            foreach(var ingrediente in Ingredientes)
            {
                toString += "  ";
                toString += ingrediente.ToString();
            }

            toString += String.Format(" Total: {0} - Peso: {1} gramas\n",Preco,CalcularPesoEmGramas());

            return toString;
        }
    }
}