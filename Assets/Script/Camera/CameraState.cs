using Cinemachine;
using Framework;

namespace SuperSport
{
	public class CameraState : State
	{
        protected WorldCamera WorldCamera { get; private set; }

        public CameraState(CameraStateMachine stateMachine, WorldCamera camera) : base(stateMachine)
        {
            WorldCamera = camera;
        }

        protected void Dispatch(CameraStateType key)
        {
            base.Dispatch((int)key);
        }

        protected void SetPriority(CinemachineVirtualCamera target)
        {
            WorldCamera.virtualCameraRace.Priority = 0;
            WorldCamera.virtualCameraTitle.Priority = 0;
            WorldCamera.virtualCameraSky.Priority = 0;
            
            if (WorldCamera.virtualCameraRace == target)
            {
                WorldCamera.virtualCameraRace.Priority = 10;
                return;
            }
            
            if (WorldCamera.virtualCameraSky == target)
            {
                WorldCamera.virtualCameraSky.Priority = 10;
                return;
            }
            
            if (WorldCamera.virtualCameraTitle == target)
            {
                WorldCamera.virtualCameraTitle.Priority = 10;
            }
        }
    }	
}