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
        Task<User> GetUser(string username, string password);
        Task<int> GetPoints(string username, string password);
        Task IncrementPoints(string username, int pointsToIncrement);
        void StoreLocally(User user);
        Task<bool> BuyReward(Reward reward);
        void SetAvatar(string username, string imageString);
    }
}
