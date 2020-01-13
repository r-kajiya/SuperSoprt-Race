using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitlePresenter : RootPresenter
    {
        [SerializeField]
        TitleView _view = null;

        public void RegisterGoQualifyingButton(Action<RaceType> onAction)
        {
            _view.GoQualifying.onClick.RemoveAllListeners();
            _view.GoQualifying.onClick.AddListener(() => { onAction?.Invoke(RaceType.Qualifying); });
        }
        
        public void RegisterGoSemifinalButton(Action<RaceType> onAction)
        {
            _view.GoSemifinal.onClick.RemoveAllListeners();
            _view.GoSemifinal.onClick.AddListener(() => { onAction?.Invoke(RaceType.Semifinal); });
        }
        
        public void RegisterGoFinalButton(Action<RaceType> onAction)
        {
            _view.GoFinal.onClick.RemoveAllListeners();
            _view.GoFinal.onClick.AddListener(() => { onAction?.Invoke(RaceType.Final); });
        }
        
        public void RegisterGoRankButton(Action<RaceType> onAction)
        {
            _view.GoRank.onClick.RemoveAllListeners();
            _view.GoRank.onClick.AddListener(() => { onAction?.Invoke(RaceType.Rank); });
        }
        
        public void RegisterGoRankingButton(Action onAction)
        {
            _view.GoRanking.onClick.RemoveAllListeners();
            _view.GoRanking.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}