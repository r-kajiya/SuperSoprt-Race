using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class RaceView : MonoBehaviour, IView
    {
        [SerializeField]
        EasyAnimation _signalAnimation = null;

        public EasyAnimation SignalAnimation => _signalAnimation;

        [SerializeField]
        Button _accelerationArea = null;

        public Button AccelerationArea => _accelerationArea;

        [SerializeField]
        Text _time = null;

        public Text Time => _time;
    }
}