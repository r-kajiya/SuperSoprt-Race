using System;
using Framework;

namespace SuperSport
{
    public class RaceUseCase : IUseCase
    {
        readonly RacePresenter _presenter;
        readonly RacePlayer _racePlayer;
        readonly RaceGoal _raceGoal;
        readonly Action _onChangeResult;

        public RaceUseCase(RacePresenter presenter, RacePlayer racePlayer, RaceGoal raceGoal, Action onChangeResult)
        {
            _presenter = presenter;
            _racePlayer = racePlayer;
            _raceGoal = raceGoal;
            _onChangeResult = onChangeResult;
            _raceGoal.RegisterEnter(OnGoal);
            _presenter.RegisterAccelerationArea(null);
            
            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _presenter.PlaySignal(() =>
                {
                    _presenter.RegisterAccelerationArea(OnAccelerator);    
                });
            },1.5f);
        }

        void OnAccelerator()
        {
            _racePlayer.Accelerator();
        }

        void OnGoal()
        {
            _onChangeResult?.Invoke();
            _racePlayer.SetupStart();
        }
        
    }
}