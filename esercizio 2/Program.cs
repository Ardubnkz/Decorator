namespace esercizio_2
{   
    #region INTERFACE
    interface ITorta
    {
        string Descrizione();
    }
    #endregion
    #region CLASSI CONCRETE
    class TortaCioccolato : ITorta
    {
        public string Descrizione()
        {
            return "Torta al cioccolato";
        }
    }
    class  TortaVaniglia : ITorta
    {
        public string Descrizione()
        {
            return "Torta alla vaniglia";
        }
    }
    class TortaFrutta : ITorta
    {
        public string Descrizione()
        {
            return "Torta alla frutta";
        }
    }
    #endregion
    #region CLASS ASTRATTA DECORARORETORTA
    abstract class DecoratoreTorta : ITorta
    {
        protected ITorta baseTorta;
        public DecoratoreTorta(ITorta baseTorta)
        {
            this.baseTorta = baseTorta;
        }
        public virtual string Descrizione()
        {
            return baseTorta.Descrizione();
        }
    }
    #endregion
    #region CLASSI CONCRETE DECORATORI
    class  ConPanna : DecoratoreTorta
    {
       public ConPanna(ITorta baseTorta) : base(baseTorta) { }
        public override string Descrizione()
        {
            return base.Descrizione() + " con panna";
        }
    }
    class ConFragole : DecoratoreTorta
    {
        public ConFragole(ITorta baseTorta) : base(baseTorta) { }
        public override string Descrizione()
        {
            return base.Descrizione() + " con fragole";
        }
    }
    class ConGlassa : DecoratoreTorta
    {
        public ConGlassa(ITorta baseTorta) : base(baseTorta) { }
        public override string Descrizione()
        {
            return base.Descrizione() + " con glassa";
        }
    }
    #endregion
    #region FACTORY
    static class TortaFactory
    {
        public static ITorta CreaTorta(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "cioccolato":
                    return new TortaCioccolato();
                case "vaniglia":
                    return new TortaVaniglia();
                case "frutta":
                    return new TortaFrutta();
                default:
                    Console.WriteLine(tipo + " non valido");
                    return null;
            }
        }
    }
    #endregion
    #region PROGRAM
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("scegli il tipo(cioccolato, vaniglia, frutta): ");
            string tipo = Console.ReadLine().ToLower().Trim();
            ITorta torta = TortaFactory.CreaTorta(tipo);
            if (torta == null)
            {
                Console.WriteLine("Tipo di torta non valido.");
                return;
            }
            Console.WriteLine("Aggiungi ingredienti extra (panna, fragole, glassa) separati da virgola o esci per terminare:");
            foreach(var ing in Console.ReadLine().ToLower().Split(','))
            {
                switch (ing.Trim())
                {
                    case "panna":
                        torta = new ConPanna(torta);
                        break;
                    case "fragole":
                        torta = new ConFragole(torta);
                        break;
                    case "glassa":
                        torta = new ConGlassa(torta);
                        break;
                    case "esci":
                        break;
                    default:
                        Console.WriteLine($"Ingrediente '{ing}' non valido.");
                        break;
                        
                }
            }
            Console.WriteLine(torta.Descrizione());


        }
    }
    #endregion
}
