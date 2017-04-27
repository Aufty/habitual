using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface UserRepository : Repository<User>
    {
        byte[] GetAvatar(string username);
        User GetUser(string username, string password);
        int GetPoints(string username);
        int IncrementPoints(int pointsToIncrement);
        void StoreLocally(User user);
    }
}
