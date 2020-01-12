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
    }
}