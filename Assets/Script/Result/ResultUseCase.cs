using System;
using System.Collections;
using Framework;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SuperSport
{
    public class ResultUseCase : IUseCase
    {
        readonly ResultPresenter _presenter;
        readonly Action _onChangeTitle;
        const float WAIT_TIME = 2f;

        public ResultUseCase(ResultPresenter presenter, RaceContextContainer raceContextContainer, Action onChangeTitle)
        {
            _presenter = presenter;
            _onChangeTitle = onChangeTitle;
            _presenter.RegisterGoTitle(null);
            _presenter.SetTimer(raceContextContainer.Time);
            _presenter.SetLength(raceContextContainer.Length);
            _presenter.Win(raceContextContainer.IsWin);
            _presenter.SetTraining(raceContextContainer.IsTraining);
            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _presenter.RegisterGoTitle(OnChangeTitle);
            },WAIT_TIME);

            if (raceContextContainer.IsTraining)
            {
                PlayerModel playerModel = PlayerRepository.I.GetOwner();
                if (playerModel == null)
                {
                    playerModel = new PlayerModel("", "", PlayerEnvironment.DEFAULT_RACE_TIME, 1, 5, 5, 5);
                }
                
                int addAcceleration = Random.Range(1, 5);
                int addFastest = Random.Range(1, 5);
                int addInitialVelocity = Random.Range(1, 5);

                playerModel = new PlayerModel(playerModel.UserID, playerModel.UserName, playerModel.RaceTime, playerModel.RaceLevel, playerModel.Acceleration + 1, playerModel.Fastest + 1, playerModel.InitialVelocity + 1);
                PlayerRepository.I.Save(playerModel);
            }
            else
            {
                if (raceContextContainer.IsWin)
                {
                    PlayerModel playerModel = PlayerRepository.I.GetOwner();
                    if (playerModel == null)
                    {
                        playerModel = new PlayerModel("", "", PlayerEnvironment.DEFAULT_RACE_TIME, 1, 5, 5, 5);
                    }

                    int addAcceleration = Random.Range(3, 10);
                    int addFastest = Random.Range(3, 10);
                    int addInitialVelocity = Random.Range(3, 10);

                    playerModel = new PlayerModel(playerModel.UserID, playerModel.UserName, playerModel.RaceTime, playerModel.RaceLevel+1, playerModel.Acceleration + addAcceleration, playerModel.Fastest + addFastest, playerModel.InitialVelocity + addInitialVelocity);
                    PlayerRepository.I.Save(playerModel);
                }
            }
        }

        void OnChangeTitle()
        {
            _onChangeTitle?.Invoke();
        }
    }
}