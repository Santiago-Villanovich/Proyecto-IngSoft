using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface IMetodosGenericos<T> where T : class
    {
        List<T> GetAll();

        T Get(int id);

        bool Insert(T obj);

        bool Update(T obj);

        bool Delete(int id);


    }
}
