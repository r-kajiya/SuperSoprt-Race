using Framework;

namespace SuperSport
{
    public interface IPlayerModel : IModel
    {
        
    }

    public class PlayerModel : IPlayerModel
    {
        public int ID { get; }
        public string UserID { get; }
        public string UserName { get; }
        public string RaceTime { get; }
        public int RaceLevel { get; }

        public PlayerModel(
            string userId,
            string userName,
            string raceTime,
            int raceLevel)
        {
            ID = userId.GetHashCode();
            UserID = userId;
            UserName = userName;
            RaceTime = raceTime;
            RaceLevel = raceLevel;
        }
    }
}