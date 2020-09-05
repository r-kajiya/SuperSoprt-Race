using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class ParameterView : MonoBehaviour, IView
    {
        [SerializeField]
        GameObject _root = null;

        public GameObject Root => _root;

        [SerializeField]
        Button _close = null;

        public Button Close => _close;

        [SerializeField]
        RectTransform _accelerationBarTransform = null;

        public RectTransform AccelerationBarTransform => _accelerationBarTransform;

        [SerializeField]
        RectTransform _fastestBarTransform = null;

        public RectTransform FastestBarTransform => _fastestBarTransform;

        [SerializeField]
        RectTransform _initialVelocityBarTransform = null;

        public RectTransform InitialVelocityBarTransform => _initialVelocityBarTransform;
    }
}