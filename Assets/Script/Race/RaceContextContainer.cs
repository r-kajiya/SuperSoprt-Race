using Framework;

namespace SuperSport
{
    public class RaceContextContainer : SystemContextContainer
    {
        public bool IsWin { get; }
        public float Time { get; }
        public bool IsRank { get; }

        public RaceContextContainer(bool isWin, float time, bool isRank)
        {
            IsWin = isWin;
            Time = time;
            IsRank = isRank;
        }
        
    }
}