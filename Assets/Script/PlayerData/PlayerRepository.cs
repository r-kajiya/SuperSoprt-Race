using Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SuperSport
{
    public class PlayerRepository : BaseRepository<PlayerModel, PlayerDataStore>
    {
        public static PlayerRepository I { get; }

        static PlayerRepository()
        {
            I = new PlayerRepository();
        }

        PlayerRepository() : base(new PlayerDataStore()) { }

        public PlayerModel GetOwner()
        {
            return base.Get(0);
        }

        public void GetRankingList(System.Action<List<PlayerModel>> onSuccess)
        {
            dataStore.FetchOrderByFirst("raceTime", 5, a => { DebugLog.Normal("aa");});
        }

    }
}