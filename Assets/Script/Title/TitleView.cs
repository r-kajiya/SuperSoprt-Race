using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class TitleView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _goGameButton;
        
        public Button GoGameButton => _goGameButton;
    }
}