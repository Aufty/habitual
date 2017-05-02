using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface Repository<T>
    {
        void Create(T entity);
        void Delete(Guid id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAllForUser(string username);
    }
}
