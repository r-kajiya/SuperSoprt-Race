using Framework;

namespace SuperSport
{
    public enum CameraStateType
    {
        Title,
        Start
    }

    public class CameraStateMachine : StateMachine<CameraState>
    {
        public CameraStateMachine(WorldCamera camera)
        {
            Register(new CameraStateTitle(this, camera), CameraStateType.Title);
            Register(new CameraStateStart(this, camera), CameraStateType.Start);

            Dispatch((int)CameraStateType.Title);
        }

        bool Register(CameraState state, CameraStateType key)
        {
            return Register(state, (int)key);
        }
    }
}