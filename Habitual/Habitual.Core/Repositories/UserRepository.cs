using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface UserRepository
    {
        void Create(User user);
        byte[] GetAvatarById(int id);
        void Delete(User user);
        User GetUserById(int id);
        User GetUser(string username, string password);
        int GetPoints(string username);
        int IncrementPoints(int pointsToIncrement);
    }
}
