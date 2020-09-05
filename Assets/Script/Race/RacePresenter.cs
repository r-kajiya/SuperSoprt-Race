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

        RacePlayerQWOP _racePlayerQwop;

        public void Setup(RacePlayerQWOP racePlayerQwop)
        {
            _view.Time.gameObject.SetActive(false);
            _view.Length.gameObject.SetActive(false);
            _racePlayerQwop = racePlayerQwop;
        }

        public void PlaySignal(Action onFinish)
        {
            _view.SignalAnimation.onFinish = onFinish; 
            _view.SignalAnimation.Play("UIStartSignal");
        }
        
        public void RegisterLeftUpper(Action onAction)
        {
            _view.LeftUpper.onClick.RemoveAllListeners();
            _view.LeftUpper.onClick.AddListener(() => { onAction?.Invoke(); });
        }
        
        public void RegisterRightUpper(Action onAction)
        {
            _view.RightUpper.onClick.RemoveAllListeners();
            _view.RightUpper.onClick.AddListener(() => { onAction?.Invoke(); });
        }
        
        public void RegisterLeftLower(Action onAction)
        {
            _view.LeftLower.onClick.RemoveAllListeners();
            _view.LeftLower.onClick.AddListener(() => { onAction?.Invoke(); });
        }
        
        public void RegisterRightLower(Action onAction)
        {
            _view.RightLower.onClick.RemoveAllListeners();
            _view.RightLower.onClick.AddListener(() => { onAction?.Invoke(); });
        }

        public void SetLength(float length)
        {
            _view.Length.text = string.Format("{0:F4}", length);
        }

        public void StartTime()
        {
            _measuring = true;
            _view.Time.gameObject.SetActive(true);
            _view.Length.gameObject.SetActive(true);
            SetLength(0);
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
                SetLength(_racePlayerQwop.Length());
                
                yield return null;
            }
        }
    }
}