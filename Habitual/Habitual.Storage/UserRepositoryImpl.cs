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
    /// <summary>
    /// Web API calls from here. Temporary code to build app before web API
    /// </summary>
    public class UserRepositoryImpl : UserRepository
    {
        public async void Create(User user)
        {
            UserDB userManager = new UserDB();
            await userManager.CreateUser(user);
            return;
        }

        public void Delete(Guid userID)
        {
            throw new NotImplementedException();
        }

        public byte[] GetAvatar(string username)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string username, string password)
        {
            UserDB userManager = new UserDB();
            var user = await userManager.GetUser(username, password);
            return user;
        }

        public int GetPoints(string username)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            return user.Points;
        }

        public async void IncrementPoints(string username, int pointsToIncrement)
        {
            UserDB userManager = new UserDB();
            await userManager.IncrementPoints(username, pointsToIncrement);
            return;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void StoreLocally(User user)
        {
            LocalData.Username = user.Username;
            LocalData.Password = user.Password;
        }

        public bool BuyReward(Reward reward)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            if (user.Points >= reward.Cost)
            {
                user.Points -= reward.Cost;
                LocalData.User = JsonConvert.SerializeObject(user);
                return true;
            } else
            {
                return false;
            }
        }

        public void SetAvatar(string username, string imageString)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            user.Avatar = Convert.FromBase64String(imageString);
            LocalData.User = JsonConvert.SerializeObject(user);
        }

        List<User> Repository<User>.GetAllForUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAll(string username)
        {
            throw new NotImplementedException();
        }
    }
}
