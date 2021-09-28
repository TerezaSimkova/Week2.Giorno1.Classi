using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.Classi
{
    public abstract class Padre // anche la classe deve avere abstract ma non puo essere istanziata (come interfacciia) definisce solo i comnportamenti
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Stampa()
        {
            return $"{Id} - {Nome}";
        }

        //metodi astratti

        public abstract void CalcolaEta(); // se sono astratti i figli devono implementare il metodo

        public virtual string Saluta() //do la possibilita di eseguire override
        {
            return $"Ciao a tutti!";
        }
    }
}
