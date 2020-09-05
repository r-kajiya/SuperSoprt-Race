using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitlePresenter : RootPresenter
    {
        [SerializeField]
        TitleView _view = null;

        public void RegisterGoRaceButton(Action onAction)
        {
            _view.GoRace.onClick.RemoveAllListeners();
            _view.GoRace.onClick.AddListener(() => { onAction?.Invoke(); });
        }

        public void RegisterGoTrainingButton(Action onAction)
        {
            _view.GoTraining.onClick.RemoveAllListeners();
            _view.GoTraining.onClick.AddListener(() => { onAction?.Invoke(); });
        }
        
        public void RegisterGoParameterButton(Action onAction)
        {
            _view.GoParameter.onClick.RemoveAllListeners();
            _view.GoParameter.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}