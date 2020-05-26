using Framework;

namespace SuperSport
{
    public class PlayerModelBase : ModelBase
    {
        
    }

    public class PlayerModel : PlayerModelBase
    {
        public int ID { get; }
        public string UserID { get; }
        public string UserName { get; }
        public float RaceTime { get; }
        public int RaceLevel { get; }

        public PlayerModel(
            string userId,
            string userName,
            float raceTime,
            int raceLevel)
        {
            // プレイヤーデータはひとつなのでIDは必ず0
            // 識別はUserIdで
            ID = 0;
            UserID = userId;
            UserName = userName;
            RaceTime = raceTime;
            RaceLevel = raceLevel;
        }
    }
}