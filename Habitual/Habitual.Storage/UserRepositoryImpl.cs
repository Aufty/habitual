using Habitual.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Habitual.Core.Entities;
using Android.Content;

namespace Habitual.Storage
{
    public class UserRepositoryImpl : UserRepository
    {
        public UserRepositoryImpl(Context context)
        {

        }
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

        public byte[] GetAvatarById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
