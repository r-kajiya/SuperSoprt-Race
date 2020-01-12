using Framework;

namespace SuperSport
{
	public class CameraStateTitle : CameraState
	{
        public CameraStateTitle(CameraStateMachine stateMachine, WorldCamera camera) : base(stateMachine, camera) { }
        
        public override void Enter(ITransitionParam transitionParam)
        {
	        SetPriority(WorldCamera.virtualCameraTitle);
        }
    }	
}