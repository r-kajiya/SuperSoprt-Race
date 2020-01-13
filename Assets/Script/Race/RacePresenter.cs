using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class RacePresenter : RootPresenter
    {
        [SerializeField]
        RaceView _view = null;
        
        float _timer;

        bool _measuring;

        public void Setup()
        {
            _view.Time.gameObject.SetActive(false);
        }

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

        public void StartTime()
        {
            _measuring = true;
            _view.Time.gameObject.SetActive(true);
            _view.Time.text = string.Format("{0:F4}", _timer);
            AbsolutelyActiveCorutine.Subscribe(UpdateTime());
        }

        public float GetTime()
        {
            return _timer;
        }

        public void StopTime()
        {
            _measuring = false;
        }

        IEnumerator UpdateTime()
        {
            _timer = 0f;

            while (_measuring)
            {
                if (_timer > 100f)
                {
                    _timer = 99.999f;
                    yield break;
                }
                
                _timer += Time.deltaTime;
                _view.Time.text = string.Format("{0:F3}", _timer);
                
                yield return null;
            }
        }
    }
}