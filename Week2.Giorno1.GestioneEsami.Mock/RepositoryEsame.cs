using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces;

namespace Week2.Giorno1.GestioneEsami.Mock
{
    public class RepositoryEsame : IRepositoryEsame
    {
        public static List<Esame> esami = new List<Esame>()
        {
             new Esame{ Id = 1, Nome = "Esame1", IdStudente = 2}
        };

        public Esame AddToListEsami(Esame esameDaSostenere)
        {
            esami.Add(esameDaSostenere);
            return esameDaSostenere;
        }

        public List<Esame> CheckEsameEsiste(Esame esameDaSostenere)
        {
            return esami.Where(e => e.Nome == esameDaSostenere.Nome).ToList();
        }

        public List<Esame> Fetch()
        {
            return esami;
        }

        public List<Esame> GetEsamiStudente(int id)
        {
            return esami.Where(e => e.IdStudente == id).ToList();
        }

        public int Insert(Esame item)
        {
            throw new NotImplementedException();
        }

        //public List<Esame> TrovaEsamiStudente(Studente studenteTrovato)
        //{
        //    return esami.FirstOrDefault(e => e.IdStudente == studenteTrovato.Id).;
        //}
    }
}
