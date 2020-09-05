using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class TitleView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _goRace = null;
        
        public Button GoRace => _goRace;
        
        [SerializeField]
        Button _goTraining = null;
        
        public Button GoTraining => _goTraining;

        [SerializeField]
        Button _goParameter = null;
        
        public Button GoParameter => _goParameter;
        
        [SerializeField]
        GameObject _selectRace = null;
        
        public GameObject SelectRace => _selectRace;
    }
}