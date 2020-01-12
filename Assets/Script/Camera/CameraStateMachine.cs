using Framework;

namespace SuperSport
{
    public enum CameraStateType
    {
        Title,
        Race,
        Sky,
    }

    public class CameraStateMachine : StateMachine<CameraState>
    {
        public CameraStateMachine(WorldCamera camera)
        {
            Register(new CameraStateTitle(this, camera), CameraStateType.Title);
            Register(new CameraStateRace(this, camera), CameraStateType.Race);
            Register(new CameraStateSky(this, camera), CameraStateType.Sky);

            Dispatch((int)CameraStateType.Title);
        }

        bool Register(CameraState state, CameraStateType key)
        {
            return Register(state, (int)key);
        }
    }
}