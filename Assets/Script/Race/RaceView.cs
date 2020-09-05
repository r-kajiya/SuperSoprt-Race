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
        Button _leftUpper;
        
        public Button LeftUpper => _leftUpper;

        [SerializeField]
        Button _rightUpper;
        
        public Button RightUpper => _rightUpper;
    
        [SerializeField]
        Button _leftLower;
        
        public Button LeftLower => _leftLower;
    
        [SerializeField]
        Button _rightLower;
        
        public Button RightLower => _rightLower;

        [SerializeField]
        Text _time = null;

        public Text Time => _time;
        
        [SerializeField]
        Text _length = null;

        public Text Length => _length;
    }
}