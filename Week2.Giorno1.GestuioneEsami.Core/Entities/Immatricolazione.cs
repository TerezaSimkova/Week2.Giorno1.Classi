using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.GestioneEsami.Core.Entities
{
    public class Immatricolazione
    {
        public int Id { get; set; }
        public int Matricola { get; set; }
        public DateTime DataInizio { get; set; }
        public CorsoDiLaurea _corsoDiLaurea { get; set; }
        public bool FuoriCorso { get; set; }
        public int CfuAccumulati { get; set; } //default zero
    }
}
