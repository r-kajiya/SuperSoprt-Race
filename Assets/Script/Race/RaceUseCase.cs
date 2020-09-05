using System;
using Framework;
using UnityEngine;

namespace SuperSport
{
    public class RaceUseCase : IUseCase
    {
        readonly RacePresenter _presenter;
        readonly RacePlayerQWOP _racePlayerQWOP;
        readonly Action<bool, float, bool, float> _onChangeResult;
        readonly Action _onChangeTitle;
        readonly RaceGoal _raceGoal;
        
        float _startTime;
        bool _isStart;
        bool _isTapped;
        int _tapCount;
        bool _isGoal;
        bool _isTraining;
        float _initialVelocity;
        int _selectRace;
        
        public RaceUseCase(RacePresenter presenter, RacePlayerQWOP racePlayerQWOP, RaceGoal raceGoal, Action<bool, float, bool, float> onChangeResult, Action onChangeTitle, int selectRace)
        {
            _presenter = presenter;
            _racePlayerQWOP = racePlayerQWOP;
            _onChangeResult = onChangeResult;
            _onChangeTitle = onChangeTitle;
            _raceGoal = raceGoal;
            _raceGoal.RegisterEnter(OnGoal);
            
            _racePlayerQWOP.Setup(OnGoal);
            _presenter.Setup(_racePlayerQWOP);
            _presenter.RegisterLeftUpper(OnAccelerationLeftUpper);
            _presenter.RegisterRightUpper(OnAccelerationRightUpper);
            _presenter.RegisterLeftLower(OnAccelerationLeftLower);
            _presenter.RegisterRightLower(OnAccelerationRightLower);

            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _isTapped = false;
                _presenter.PlaySignal(() =>
                {
                    _startTime = Time.realtimeSinceStartup;
                    _isStart = true;
                    _presenter.StartTime();
                    _racePlayerQWOP.Go();
                });
            },1.5f);

            _startTime = 0f;
            _tapCount = 0;
            _isStart = false;
            _isGoal = false;
            _selectRace = selectRace;
        }

        void OnAccelerationLeftUpper()
        {
            _racePlayerQWOP.OnLeftUpper();
        }
        
        void OnAccelerationRightUpper()
        {
            _racePlayerQWOP.OnRightUpper();
        }
        
        void OnAccelerationLeftLower()
        {
            _racePlayerQWOP.OnLeftLower();
        }
        
        void OnAccelerationRightLower()
        {
            _racePlayerQWOP.OnRightLower();
        }

        void OnGoal(bool isWin)
        {
            float time = _presenter.GetTime();
            float length = _racePlayerQWOP.Length();
            _onChangeResult?.Invoke(isWin, time, _isTraining, length);
            _raceGoal.RegisterEnter(null);
            _presenter.StopTime();

            if (isWin)
            {
                var owner = PlayerRepository.I.GetOwner();

                if (owner == null)
                {
                    PlayerRepository.I.Save(new PlayerModel("","",time, _selectRace+1, 0, 0, 0));
                }

                if (owner.RaceLevel == _selectRace)
                {
                    PlayerRepository.I.Save(new PlayerModel("","",time, _selectRace+1, 0, 0, 0));
                }
            }
        }
    }
}