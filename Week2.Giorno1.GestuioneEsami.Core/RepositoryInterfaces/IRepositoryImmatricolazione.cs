using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;

namespace Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces
{
    public interface IRepositoryImmatricolazione : IRepository<Immatricolazione>
    {
        public Immatricolazione GetIdByDate(Immatricolazione imm);
        List<Immatricolazione> FetchById(Studente studenteTrovato);
        Immatricolazione FindImm(int id);
    }
}
