using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces;

namespace Week2.Giorno1.GestioneEsami.Mock
{
    public class RepositoryImmatricolazione : IRepositoryImmatricolazione
    {

        public static List<Immatricolazione> immatricolazioni = new List<Immatricolazione>()
        {

        };

        public List<Immatricolazione> Fetch()
        {
            return immatricolazioni;
        }

        public List<Immatricolazione> FetchById(Studente studenteTrovato)
        {
            var t = immatricolazioni.Where(i => i.Id == studenteTrovato.Id).ToList();
            return t;
        }

        public Immatricolazione FindImm(int id)
        {
            return immatricolazioni.FirstOrDefault(i => i.Id == id);
        }

        public Immatricolazione GetIdByDate(Immatricolazione imm)
        {
            return immatricolazioni.Where(i => i.DataInizio == imm.DataInizio).SingleOrDefault();
        }

        public int Insert(Immatricolazione item)
        {
            if (immatricolazioni.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = immatricolazioni.Max(i => i.Id) + 1;
            }
            immatricolazioni.Add(item);
            return item.Id;

        }
    }
}
