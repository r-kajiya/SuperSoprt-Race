using UnityEngine;
using Framework;
using UnityEngine.UI;

namespace SuperSport
{
    public class TitleView : MonoBehaviour, IView
    {
        [SerializeField]
        Button _goQualifying = null;
        
        public Button GoQualifying => _goQualifying;
        
        [SerializeField]
        Button _goSemifinal = null;
        
        public Button GoSemifinal => _goSemifinal;
        
        [SerializeField]
        Button _goFinal = null;
        
        public Button GoFinal => _goFinal;
        
        [SerializeField]
        Button _goRank = null;
        
        public Button GoRank => _goRank;
        
        [SerializeField]
        Button _goRanking = null;
        
        public Button GoRanking => _goRanking;
    }
}