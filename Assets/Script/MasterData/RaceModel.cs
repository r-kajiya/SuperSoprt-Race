using Framework;

namespace SuperSport
{
    public class RaceModelBase : ModelBase
    {
        
    }

    public class RaceModel : RaceModelBase
    {
        public int RaceLevel { get; }
        public float ForceB { get; }
        public float ForceC { get; }
        public float ForceD { get; }
        public float ForceE { get; }
        public float BoostValueB { get; }
        public int BoostTimingB { get; }
        public float BoostValueC { get; }
        public int BoostTimingC { get; }
        public float BoostValueD { get; }
        public int BoostTimingD { get; }
        public float BoostValueE { get; }
        public int BoostTimingE { get; }
        
        public RaceModel(int raceLevel, float forceB, float forceC, float forceD, float forceE, float boostValueB, int boostTimingB, float boostValueC, int boostTimingC, float boostValueD, int boostTimingD, float boostValueE, int boostTimingE)
        {
            RaceLevel = raceLevel;
            ForceB = forceB;
            ForceC = forceC;
            ForceD = forceD;
            ForceE = forceE;
            BoostValueB = boostValueB;
            BoostTimingB = boostTimingB;
            BoostValueC = boostValueC;
            BoostTimingC = boostTimingC;
            BoostValueD = boostValueD;
            BoostTimingD = boostTimingD;
            BoostValueE = boostValueE;
            BoostTimingE = boostTimingE;
        }
    }
}