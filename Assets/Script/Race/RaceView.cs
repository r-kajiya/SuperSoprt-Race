using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class RaceView : MonoBehaviour, IView
    {
        [SerializeField]
        LegacyEasyAnimation _signalAnimation = null;

        public LegacyEasyAnimation SignalAnimation => _signalAnimation;

        [SerializeField]
        Button _accelerationArea = null;

        public Button AccelerationArea => _accelerationArea;

        [SerializeField]
        Text _time = null;

        public Text Time => _time;
    }
}