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
        Task<User> GetUser(string username, string password);
        int GetPoints(string username);
        Task IncrementPoints(string username, int pointsToIncrement);
        void StoreLocally(User user);
        Task<bool> BuyReward(Reward reward);
        void SetAvatar(string username, string imageString);
    }
}
