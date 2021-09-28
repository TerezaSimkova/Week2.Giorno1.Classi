using System;

namespace Week2.Giorno1.FigureGeometriche
{
    class Program
    {

        //Scrivere un programma che calcola perimetro e area delle sequanti figure geometriche

        //tutte le figure geometriche hanno una proprieta Nome 
        // cerchio -> coordinate del centro, raggio
        // retangolo -> base ,altezza
        //Triangolo -> base, altezze ,lato 1 ,lato 2

        //Tutte figure geometriche hanno un metodo che stampa il nome ,un metodo che stampa il perimetro, u nmetodo che stampa area

        static void Main(string[] args)
        {
            //CERCHIO

            // Dot notation - costruttore di default
            Cerchio c = new Cerchio();
            c.Nome = "Cerchio";

            Centro centro = new Centro();
            centro.x = 5;
            centro.y = 2.2;
            c.CoordCentro = centro;

            c.Raggio = 12;

            Console.WriteLine($"{c.PrintNome()}");
            Console.WriteLine($"{c.PrintPerimetro()}");
            c.CalcolaArea();
            Console.WriteLine($"{c.PrintArea()}");

            //RETANGOLO

            Rettangolo r = new Rettangolo();
            r.Nome = "Rettangolo";
            r.Base = 7.5;
            r.Altezza = 14.3;

            Console.WriteLine($"{r.PrintNome()}");
            Console.WriteLine($"{r.PrintPerimetro()}");
            r.CalcolaArea();
            Console.WriteLine($"{r.PrintArea()}");

            //TRIANGOLO

            Triangolo t = new Triangolo();

            t.Nome = "Triangolo";
            t.Lato1 = 3;
            t.Lato2 = 5;
            t.Base = 6;
            t.Altezza = 13.5;

            Console.WriteLine($"{t.PrintNome()}");
            Console.WriteLine($"{t.PrintPerimetro()}");
            t.CalcolaArea();
            Console.WriteLine($"{t.PrintArea()}");

            
        }
    }
}
