using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.GestioneEsami.Core.Entities
{
    public class Corso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CreditiFormativi { get; set; }
        public int IdCorsoDiLaurea { get; set; }
        public string Print()
        {
            return $"{Nome} per {CreditiFormativi} CFU.";
        }
    }


}

//CorsoDiLaurea -> metematica

//AnniC ->3
//CFU -.Somma dei corsi - 30+ 40 + 30 = 100

//Corso
//Nome - Geometria -   analisi matematica     Logica 
//Cfu - > 30           - 40                   -30

//CorsoDiLaurea -> lettere
//anniC ->3
//CFU -> 25+ 10 + 32 = 67

//Corso
//Nome -> Stroia Greca      -Storia Latina      -Grammatica
// Cfu    - 25              - 10                   -32
