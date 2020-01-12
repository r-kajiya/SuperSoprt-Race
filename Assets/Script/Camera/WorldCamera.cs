using Cinemachine;
using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Camera))]
	public class WorldCamera : MonoBehaviour
	{
        public new Camera camera;

        public CinemachineVirtualCamera virtualCameraTitle;
        public CinemachineVirtualCamera virtualCameraRace;
        public CinemachineVirtualCamera virtualCameraSky;
    }	
}