using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class RegistView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _close = null;
        
        public Button Close => _close;
        
        [SerializeField]
        Button _decision = null;
        
        public Button Decision => _decision;
        
        [SerializeField]
        Text _nameText = null;
        
        public Text NameText => _nameText;
        
        public void SetActive(bool enable)
        {
            gameObject.SetActive(enable);
        }
    }
}