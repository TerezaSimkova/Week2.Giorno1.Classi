using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.Classi
{
    class LaMiaClasse
    {
        //Campi
        public int count;
        public string nome;
        public int id;
        public int eta;

        //Proprieta
        public int Id { get; set; }
        public int Eta //voglio che utente mi passa lanno della nascita e voglio che succede prima che uso questo campo
        {
            get
            {
                return eta;
            }
            set
            {
                //2021 - 1991
                eta = DateTime.Now.Year - value; // controlli mancanti
            }
        }
        //get,set
        public int EdExsplicito
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Nome { get; private set; } //posso usare get ma non set

        public string Cognome { private get; set; } // posso usare set ma non get 

        //costruttore default
        public LaMiaClasse()
        {

        }

        public LaMiaClasse(int id)
        {
            Id = id;//alla mia proprieta Id metti mi valore di id
        }

        //Metodi

        public string StampaNome()
        {
            return $"{Nome}";
        }

        //Non si usano molto i distruttori
        //cosa vogliamo che fa per liberare la memoria
        ~LaMiaClasse()
        {
            //lmc = null;
        }
            
    }
}
