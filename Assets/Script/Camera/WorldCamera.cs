using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Camera))]
	public class WorldCamera : MonoBehaviour
	{
        public new Camera camera;

        public Transform cameraTransform;

        public Transform lookAt;

        public Transform follow;
        void Awake()
        {
            cameraTransform = transform;
        }
    }	
}