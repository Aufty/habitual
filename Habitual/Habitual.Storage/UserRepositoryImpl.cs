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
            var test = user.Username;
            var test2 = user.Password;
            return;
        }

        public void Delete(User user)
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
            if (username.ToLower() == "admin")
            {
                return JsonConvert.DeserializeObject<User>(LocalData.User);
            }
            else return null;
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
    }
}
