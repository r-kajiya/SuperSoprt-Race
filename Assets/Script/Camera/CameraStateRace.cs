using Framework;

namespace SuperSport
{
    public class CameraStateRace : CameraState
    {
        public CameraStateRace(CameraStateMachine stateMachine, WorldCamera camera) : base(stateMachine, camera) { }

        public override void Enter(ITransitionParam transitionParam)
        {
            SetPriority(WorldCamera.virtualCameraRace);
        }
    }
}
