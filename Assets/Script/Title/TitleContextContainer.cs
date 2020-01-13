using Framework;

namespace SuperSport
{
    public class TitleContextContainer : SystemContextContainer
    {
        public RaceType RaceType { get; }

        public TitleContextContainer(RaceType raceType)
        {
            RaceType = raceType;
        }
        
    }
}