using System;
using Framework;
using UnityEngine;

namespace SuperSport
{
    public class RaceUseCase : IUseCase
    {
        readonly RacePresenter _presenter;
        readonly RacePlayer _racePlayer;
        readonly RaceNPC[] _raceNpcs;
        readonly Action _onChangeResult;
        readonly Action _onChangeTitle;
        readonly RaceGoal _raceGoal;
        
        float _startTime;
        bool _isStart;
        bool _isTapped;
        int _tapCount;

        public RaceUseCase(RacePresenter presenter, RacePlayer racePlayer, RaceGoal raceGoal, RaceNPC[] raceNpcs, Action onChangeResult, Action onChangeTitle)
        {
            _presenter = presenter;
            _racePlayer = racePlayer;
            _raceNpcs = raceNpcs;
            _onChangeResult = onChangeResult;
            _onChangeTitle = onChangeTitle;
            _raceGoal = raceGoal;
            _raceGoal.RegisterEnter(OnGoal);
            _presenter.RegisterAccelerationArea(OnAccelerator);
            _presenter.Setup();
            _startTime = 0f;
            _tapCount = 0;
            _isStart = false;
            
            _racePlayer.SetupStart();
            foreach (var raceNpc in _raceNpcs)
            {
                raceNpc.SetupStart();
            }

            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _isTapped = false;
                _presenter.PlaySignal(() =>
                {
                    _startTime = Time.realtimeSinceStartup;
                    _isStart = true;
                    _presenter.StartTime();
                    foreach (var _raceNpc in _raceNpcs)
                    {
                        _raceNpc.StartRun();
                    }
                });
            },1.5f);
        }

        void OnAccelerator()
        {
            float boost = 1f;
            float diff = 1f;

            if (!_isTapped)
            {
                diff = Time.realtimeSinceStartup - _startTime;
                _isTapped = true;
            }

            if (!_isStart)
            {
                if (_isTapped)
                {
                    DebugLog.Normal("お手つき：ブーストされない");
                }
                return;
            }

            _tapCount++;
            
            if (diff < 0.01f)
            {
                boost = 10f;
            }
            else if (diff < 0.02f)
            {
                boost = 8f;
            }
            else if (diff < 0.05f)
            {
                boost = 6f;
            }
            else if (diff < 0.1f)
            {
                boost = 5f;
            }
            else if (diff < 0.2f)
            {
                boost = 3f;
            }
            else if (diff < 0.5f)
            {
                boost = 2f;
            }
            else if (diff < 1.0f)
            {
                boost = 1.5f;
            }

            if (boost > 1.0f)
            {
                DebugLog.Normal($"ブースト：{boost:F2}倍, 差分:{diff:F4}");
            }

            _racePlayer.Accelerator(boost);
        }

        void OnGoal()
        {
            foreach (var _raceNpc in _raceNpcs)
            {
                _raceNpc.StopRun();
            }
            
            DebugLog.Normal($"タップ回数：{_tapCount}");
            _presenter.StopTime();
            _onChangeResult?.Invoke();
            _raceGoal.RegisterEnter(null);
        }
        
    }
}