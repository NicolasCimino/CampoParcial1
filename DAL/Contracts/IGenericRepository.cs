using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IGenericRepository<T>
    {
        void Insert (T obj);
        void Update (Guid id,T obj);
        void Delete (Guid id);
        List<T> GetAll ();
        T GetOne (Guid id);

    }
}
