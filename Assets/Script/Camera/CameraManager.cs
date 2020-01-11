using UnityEngine;
using Framework;

namespace SuperSport
{
    public class CameraManager : MonoSingleton<CameraManager>
	{
        [SerializeField]
        WorldCamera _gameCamera;

        public WorldCamera GameCamera { get { return _gameCamera; } }
        
        CameraStateMachine _stateMachine;

        protected override void OnAwake()
        {
            FindOrCreateGameCamera();
            _stateMachine = new CameraStateMachine(GameCamera);
        }

        void LateUpdate()
        {
            _stateMachine.Update();
        }

        void FindOrCreateGameCamera()
        {
            if (_gameCamera != null)
            {
                return;
            }

            _gameCamera = GameObject.FindObjectOfType<WorldCamera>();

            if(_gameCamera == null)
            {
                var prefab = Resources.Load<WorldCamera>("Camera/GameCamera");
                _gameCamera = GameObject.Instantiate<WorldCamera>(prefab);
                _gameCamera.name = "GameCamera";
            }
        }

        public void RequestCameraState(CameraStateType stateType)
        {
            _stateMachine.Dispatch((int)stateType);
        }
    }
}