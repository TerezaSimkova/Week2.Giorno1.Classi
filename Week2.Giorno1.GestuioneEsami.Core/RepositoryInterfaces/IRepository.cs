using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        public List<T> Fetch();
        public int Insert(T item);
    }
}
