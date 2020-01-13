using Framework;

namespace SuperSport
{
    public class PlayerRepository : BaseRepository<PlayerModel, PlayerEntity, PlayerDataStore>
    {
        public static PlayerRepository I { get; }

        static PlayerRepository()
        {
            I = new PlayerRepository();
        }

        PlayerRepository() : base(new PlayerDataStore()) { }

        public PlayerModel GetOwner()
        {
            var list = base.GetAll();
            if (list.Count == 0)
            {
                return null;
            }
            
            return list[0];
        }
    }
}