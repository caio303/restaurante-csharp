namespace RestauranteIndra.Models
{
    internal class Ingrediente
    {
        public string Nome { get; set; }
        public int? PesoEmGramas { get; set; }
        public bool EhLiquido { get; set; }
        public int? VolumeEmMililitros { get; set; }

        public Ingrediente(string nome,bool ehLiquido,int volumeOuPeso)
        {
            Nome = nome;
            EhLiquido = ehLiquido;
            if (EhLiquido)
            {
                VolumeEmMililitros = volumeOuPeso;
                PesoEmGramas = null;
            }
            else
            {
                PesoEmGramas = volumeOuPeso;
                VolumeEmMililitros = null;
            }
        }

        public Ingrediente(string nome, int pesoEmGramas)
        {
            Nome = nome;
            PesoEmGramas = pesoEmGramas;
            EhLiquido= false;
        }

        public override string ToString()
        {
            string toString = "";

            toString += string.Format("{0}", Nome);

            if (PesoEmGramas != null) toString += string.Format(": {0} gramas\n", PesoEmGramas);
            else toString += string.Format(": {0} mililitros\n", VolumeEmMililitros);

            return toString;
        }
    }
}
