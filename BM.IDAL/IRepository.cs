using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.IDAL
{
    public interface IRepository<T>
    {
        int Add(T model);
        int Remove(Func<T, bool> func);
        int Update(T model);
        List<T> GetAll();
        List<T> Getlist(Func<T, bool> func,Func<T,object> order);
        T Get(Func<T, bool> func);
    }
}
