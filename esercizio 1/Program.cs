namespace esercizio_1
{
    internal class Program
    {
        #region INTERFACE
        interface IBeveranda
        {
            string descrizione();
            double costo();
        }
        #endregion
        #region CLASS CAFFE' E TE'
        class Caffe : IBeveranda
        {
            public string descrizione()
            {
                return "Caffe";
            }
            public double costo()
            {
                return 1.0;
            }
        }
        class Te : IBeveranda
        {
            public string descrizione()
            {
                return "Te";
            }
            public double costo()
            {
                return 1.5;
            }
        }
        #endregion
        #region ABSTRACT CLASS
        abstract class DecoratorBevanda : IBeveranda
        {
            protected IBeveranda bevanda;
            public DecoratorBevanda(IBeveranda bevanda)
            {
                this.bevanda = bevanda;
            }
            public virtual string descrizione()
            {
                return bevanda.descrizione();
            }
            public virtual double costo()
            {
                return bevanda.costo();
            }
        }
        #endregion
        #region CLASS CONCRETE DECORATORS
        class ConLatte : DecoratorBevanda
        {
            public ConLatte(IBeveranda bevanda) : base(bevanda) { }
            public override string descrizione()
            {
                return bevanda.descrizione() + ", con latte";
            }
            public override double costo()
            {
                return bevanda.costo() + 0.5;
            }
        }
        class ConCioccolato : DecoratorBevanda
        {
            public ConCioccolato(IBeveranda bevanda) : base(bevanda) { }
            public override string descrizione()
            {
                return bevanda.descrizione() + ", con cioccolato";
            }
            public override double costo()
            {
                return bevanda.costo() + 0.7;
            }
        }
        class ConPanna : DecoratorBevanda
        {
            public ConPanna(IBeveranda bevanda) : base(bevanda) { }
            public override string descrizione()
            {
                return bevanda.descrizione() + ", con panna";
            }
            public override double costo()
            {
                return bevanda.costo() + 0.6;
            }
        }
        #endregion
        #region MAIN    
        static void Main(string[] args)
        {
            IBeveranda caffe = new Caffe();
            caffe = new ConLatte(caffe);
            caffe = new ConCioccolato(caffe);
            Console.WriteLine($"{caffe.descrizione()} - Costo: {caffe.costo()}");
            IBeveranda te = new Te();
            te = new ConPanna(te);
            Console.WriteLine($"{te.descrizione()} - Costo: {te.costo()}");
            IBeveranda Caffe2 = new Caffe();
            Console.WriteLine(Caffe2.descrizione());
            Console.WriteLine(Caffe2.costo());
            Caffe2 = new ConCioccolato(Caffe2);
            Console.WriteLine(Caffe2.descrizione() + " - Costo: " + Caffe2.costo());
        }
        #endregion
    }
}
