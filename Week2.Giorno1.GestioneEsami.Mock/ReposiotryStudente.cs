using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces;

namespace Week2.Giorno1.GestioneEsami.Mock
{
    public class ReposiotryStudente : IRepositoryStudente
    {
        public static List<Studente> studenti = new List<Studente>()
        {
            //new Studente{ Id = 1, Nome = "Tereza" ,Cognome = "Simkova", AnnoDiNascita=1995}
        };

        public List<Studente> Fetch()
        {
            return studenti;
        }

        public Studente FetchByNomeECognome(string nome, string cognome)
        {
            Studente s = studenti.Find(s => s.Nome == nome && s.Cognome == cognome);
            return s;
        }

        public int Insert(Studente item)
        {
            if (studenti.Count() == 0)
                item.Id = 1;
            else
                item.Id = studenti.Max(s => s.Id) + 1;
            studenti.Add(item);
            return item.Id;
        }

    }
}
