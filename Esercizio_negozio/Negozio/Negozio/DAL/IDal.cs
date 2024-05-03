using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PURIFICAMI_SIGNORE.DAL
{
    interface IDal<T>
    {
        T FindByID(int id);
        bool Insert(T t);
        List<T> GetAll();
        bool Update(T t);
        bool DeleteByID(int id);
    }
}
