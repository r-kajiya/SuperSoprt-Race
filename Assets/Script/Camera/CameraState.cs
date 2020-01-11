using Framework;

namespace SuperSport
{
	public class CameraState : State
	{
        protected WorldCamera GameCamera { get; private set; }

        public CameraState(CameraStateMachine stateMachine, WorldCamera camera) : base(stateMachine)
        {
            GameCamera = camera;
        }

        protected void Dispatch(CameraStateType key)
        {
            base.Dispatch((int)key);
        }
    }	
}