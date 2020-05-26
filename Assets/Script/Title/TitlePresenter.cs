using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitlePresenter : RootPresenter
    {
        [SerializeField]
        TitleView _view = null;

        public void AllDeActive()
        {
            _view.GoQualifying.interactable = false;
            _view.GoSemifinal.interactable = false;
            _view.GoFinal.interactable = false;
            _view.GoRank.interactable = false;
            _view.GoRanking.interactable = false;
        }

        public void RegisterGoQualifyingButton(Action<RaceType> onAction, bool active)
        {
            _view.GoQualifying.interactable = active;

            if (!active)
            {
                return;
            }
            
            _view.GoQualifying.onClick.RemoveAllListeners();
            _view.GoQualifying.onClick.AddListener(() => { onAction?.Invoke(RaceType.Qualifying); });
        }

        public void RegisterGoSemifinalButton(Action<RaceType> onAction, bool active)
        {
            _view.GoSemifinal.interactable = active;

            if (!active)
            {
                return;
            }
            
            _view.GoSemifinal.onClick.RemoveAllListeners();
            _view.GoSemifinal.onClick.AddListener(() => { onAction?.Invoke(RaceType.Semifinal); });
        }
        
        public void RegisterGoFinalButton(Action<RaceType> onAction, bool active)
        {
            _view.GoFinal.interactable = active;

            if (!active)
            {
                return;
            }
            
            _view.GoFinal.onClick.RemoveAllListeners();
            _view.GoFinal.onClick.AddListener(() => { onAction?.Invoke(RaceType.Final); });
        }
        
        public void RegisterGoRankButton(Action<RaceType> onAction, bool active)
        {
            _view.GoRank.interactable = active;

            if (!active)
            {
                return;
            }
            
            _view.GoRank.onClick.RemoveAllListeners();
            _view.GoRank.onClick.AddListener(() => { onAction?.Invoke(RaceType.Rank); });
        }
        
        public void RegisterGoRankingButton(Action onAction, bool active)
        {
            _view.GoRanking.interactable = active;

            if (!active)
            {
                return;
            }
            
            _view.GoRanking.onClick.RemoveAllListeners();
            _view.GoRanking.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}