using Framework;

namespace SuperSport
{
    public class CameraStateSky : CameraState
    {
        public CameraStateSky(CameraStateMachine stateMachine, WorldCamera camera) : base(stateMachine, camera) { }

        public override void Enter(ITransitionParam transitionParam)
        {
            SetPriority(WorldCamera.virtualCameraSky);
        }
    }
}
