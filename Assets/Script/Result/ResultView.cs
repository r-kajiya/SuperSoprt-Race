using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class ResultView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _goTitle = null;

        public Button GoTitle => _goTitle;

        [SerializeField]
        GameObject _win = null;

        public GameObject Win => _win;
        
        [SerializeField]
        GameObject _lose = null;
        
        public GameObject Lose => _lose;
        
        [SerializeField]
        GameObject _training = null;
        
        public GameObject Training => _training;
        
        [SerializeField]
        Text _timeText = null;
        
        public Text TimeText => _timeText;
        
        [SerializeField]
        Text _lengthText = null;
        
        public Text LengthText => _lengthText;
    }
}