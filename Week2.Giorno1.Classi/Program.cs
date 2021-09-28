using System;

namespace Week2.Giorno1.Classi
{
    class Program
    {
        static void Main(string[] args)
        {
            LaMiaClasse lmc = new LaMiaClasse();

            lmc = null; // variabile viene liberata prima della fine 


            //Padre p = new Padre();
            //p.Id = 1;
            //p.Nome = "padre";

            Figlia f = new Figlia();
            f.Id = 2;
            f.Nome = "Figlia";
            f.Cognome = "Cognome del figlio";

            //p.Stampa();
            //f.Stampa();
        }
    }
}
