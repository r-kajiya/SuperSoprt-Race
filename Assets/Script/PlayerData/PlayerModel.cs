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
        public int Acceleration { get; }
        public int Fastest { get; }
        public int InitialVelocity { get; }

        public PlayerModel()
        {
            ID = 0;
            UserID = "";
            UserName = "";
            RaceTime = 0;
            RaceLevel = 0;
            Acceleration = 0;
            Fastest = 0;
            InitialVelocity = 0;
        }

        public PlayerModel(
            string userId,
            string userName,
            float raceTime,
            int raceLevel,
            int acceleration,
            int fastest,
            int initialVelocity)
        {
            // プレイヤーデータはひとつなのでIDは必ず0
            // 識別はUserIdで
            ID = 0;
            UserID = userId;
            UserName = userName;
            RaceTime = raceTime;
            RaceLevel = raceLevel;
            Acceleration = acceleration;
            Fastest = fastest;
            InitialVelocity = initialVelocity;
        }
    }
}