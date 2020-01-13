using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class RankingView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _close = null;
        
        public Button Close => _close;
        
        public void SetActive(bool enable)
        {
            gameObject.SetActive(enable);
        }
    }
}