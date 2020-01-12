using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class TitleView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _goRaceButton = null;
        
        public Button GoRaceButton => _goRaceButton;
    }
}