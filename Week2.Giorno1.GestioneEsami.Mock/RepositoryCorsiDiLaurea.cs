using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces;

namespace Week2.Giorno1.GestioneEsami.Mock
{
    public class RepositoryCorsiDiLaurea : IRepositoryCorsiLaurea
    {
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>()
        {
            new CorsoDiLaurea { Id = 1, Nome= "Matematica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 2, Nome = "Fisica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 3, Nome = "Informatica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 4, Nome = "Ingeneria", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 5, Nome = "Lettere", AnniDiCorso = 3},
        };

        public List<CorsoDiLaurea> Fetch()
        {
            return corsiDiLaurea;
        }

        public int Insert(CorsoDiLaurea item)
        {
            throw new NotImplementedException();
        }
        //fetch
    }
}
