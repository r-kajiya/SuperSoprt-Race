using Framework;

namespace SuperSport
{
    public class RaceContextContainer : SystemContextContainer
    {
        public bool IsWin { get; }
        public float Time { get; }
        public bool IsTraining { get; }
        public float Length { get; }
        public RaceContextContainer(bool isWin, float time, bool isTraining, float length)
        {
            IsWin = isWin;
            Time = time;
            IsTraining = isTraining;
            Length = length;
        }
        
    }
}