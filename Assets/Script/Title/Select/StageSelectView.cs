using System.Collections.Generic;
using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class StageSelectView : MonoBehaviour, IView
    {
        [SerializeField]
        GameObject _selectRace = null;
        
        public GameObject SelectRace => _selectRace;
        
        [SerializeField]
        List<Button> _buttons = null;
        
        public List<Button> Buttons => _buttons;
        
        [SerializeField]
        Button _close = null;
        
        public Button Close => _close;
    }
}

