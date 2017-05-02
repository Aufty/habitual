using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.Repositories;
using Habitual.Storage.Local;
using Newtonsoft.Json;

namespace Habitual.Storage
{
    public class RewardRepositoryImpl : RewardRepository
    {
        public bool BuyReward(Reward reward)
        {
            throw new NotImplementedException();
        }

        public void Create(Reward reward)
        {
            var rewards = JsonConvert.DeserializeObject<List<Reward>>(LocalData.Rewards);
            rewards.Add(reward);
            LocalData.Rewards = JsonConvert.SerializeObject(rewards);
        }

        public void Delete(Guid id)
        {
            var rewards = JsonConvert.DeserializeObject<List<Reward>>(LocalData.Rewards);
            var matchingItem = rewards.First(t => t.ID == id);
            rewards.Remove(matchingItem);
            LocalData.Rewards = JsonConvert.SerializeObject(rewards);
        }

        public List<Reward> GetAllForUser(string username)
        {
            var rewards = JsonConvert.DeserializeObject<List<Reward>>(LocalData.Rewards);
            if (rewards == null || rewards.Count == 0)
            {
                var reward = new Reward();
                reward.Username = username;
                reward.Description = "Test Reward";
                reward.Cost = 100;
                rewards = new List<Reward>();
                rewards.Add(reward);
                LocalData.Rewards = JsonConvert.SerializeObject(rewards);
            }
            return rewards;
        }

        public Reward GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reward entity)
        {
            throw new NotImplementedException();
        }
    }
}
