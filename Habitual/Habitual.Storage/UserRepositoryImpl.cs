using Habitual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Habitual.Core.Entities;
using Android.Content;
using Habitual.Storage.Local;
using Newtonsoft.Json;

namespace Habitual.Storage
{
    /// <summary>
    /// Web API calls from here. Temporary code to build app before web API
    /// </summary>
    public class UserRepositoryImpl : UserRepository
    {
        public void Create(User user)
        {
            TemporaryStorageGenerator.CreateUser(user.Username, user.Password);
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

        public User GetUser(string username, string password)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            if (JsonConvert.DeserializeObject<User>(LocalData.User).Username == username)
            {
                return JsonConvert.DeserializeObject<User>(LocalData.User);
            }
            return null;
        }

        public int GetPoints(string username)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            return user.Points;
        }

        public int IncrementPoints(int pointsToIncrement)
        {
            var user = JsonConvert.DeserializeObject<User>(LocalData.User);
            user.Points += pointsToIncrement;
            LocalData.User = JsonConvert.SerializeObject(user);
            return user.Points;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllForUser(string username)
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
    }
}
