using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class RacePresenter : RootPresenter
    {
        [SerializeField]
        RaceView _view = null;

        public void PlaySignal(Action onFinish)
        {
            _view.SignalAnimation.onFinish = onFinish; 
            _view.SignalAnimation.Play("UIStartSignal");
        }
        
        public void RegisterAccelerationArea(Action onAction)
        {
            _view.AccelerationArea.onClick.RemoveAllListeners();
            _view.AccelerationArea.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}