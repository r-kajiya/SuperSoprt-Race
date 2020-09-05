using Framework;

namespace SuperSport
{
    public class TitleContextContainer : SystemContextContainer
    {
        public int SelectRace {
            get;
        }

        public TitleContextContainer(int selectRace)
        {
            SelectRace = selectRace;
        }
    }
}