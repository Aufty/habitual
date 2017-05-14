using Habitual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Habitual.Core.Entities;
using Android.Content;
using Habitual.Storage.Local;
using Newtonsoft.Json;
using Habitual.Storage.DB;
using System.Threading.Tasks;

namespace Habitual.Storage
{
    public class UserRepositoryImpl : UserRepository
    {
        public async Task Create(User user)
        {
            UserDB userManager = new UserDB();
            await userManager.CreateUser(user);
            return;
        }

        //Not used for User
        public Task Delete(Guid userID)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string username, string password)
        {
            UserDB userManager = new UserDB();
            var user = await userManager.GetUser(username, password);
            return user;
        }

        public async Task<int> GetPoints(string username, string password)
        {
            UserDB userManager = new UserDB();
            var user = await userManager.GetUser(username, password);
            return user.Points;
        }

        public async Task IncrementPoints(string username, int pointsToIncrement)
        {
            UserDB userManager = new UserDB();
            await userManager.IncrementPoints(username, pointsToIncrement);
            return;
        }

        public void StoreLocally(User user)
        {
            LocalData.Username = user.Username;
            LocalData.Password = user.Password;
        }

        public async Task<bool> BuyReward(Reward reward)
        {
            RewardDB rewardManager = new RewardDB();
            var result = await rewardManager.BuyReward(reward);
            return result;
        }

        public void SetAvatar(string username, string imageString)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            user.Avatar = Convert.FromBase64String(imageString);
            LocalData.User = JsonConvert.SerializeObject(user);
        }

        //Not used for User
        public Task<List<User>> GetAll(string username)
        {
            throw new NotImplementedException();
        }
    }
}
