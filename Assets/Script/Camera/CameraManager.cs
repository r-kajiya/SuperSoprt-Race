using UnityEngine;
using Framework;

namespace SuperSport
{
    public class CameraManager : MonoSingleton<CameraManager>
	{
        [SerializeField]
        WorldCamera _worldCamera;

        CameraStateMachine _stateMachine;

        protected override void OnAwake()
        {
            FindOrCreateGameCamera();
            _stateMachine = new CameraStateMachine(_worldCamera);
        }

        void LateUpdate()
        {
            _stateMachine.Update();
        }

        void FindOrCreateGameCamera()
        {
            if (_worldCamera != null)
            {
                return;
            }

            _worldCamera = GameObject.FindObjectOfType<WorldCamera>();
        }

        public void RequestCameraState(CameraStateType stateType)
        {
            _stateMachine.Dispatch((int)stateType);
        }
    }
}