using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.Classi
{
    public class Figlia : Padre
    {

        //eredita dal padre

        public string Cognome { get; set; }

        public override void CalcolaEta()
        {
            throw new NotImplementedException();
        }

        public string Stampa()
        {
            return $"{base.Stampa()} - {Cognome}"; // ikl primo pezzo stampami quello del padre ma aggiungi anche cognome
        }

        public override string Saluta()
        {
            return $"Buonasera a tutti!";
        }
    }
}
