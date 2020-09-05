using System;
using System.Collections.Generic;
using Framework;

namespace SuperSport
{
    public class ParameterUseCase : IUseCase
    {
        readonly ParameterPresenter _presenter;

        public ParameterUseCase(ParameterPresenter presenter)
        {
            _presenter = presenter;
            _presenter.RegisterCloseButton(Close);

            PlayerModel playerModel = PlayerRepository.I.GetOwner();
            if (playerModel == null)
            {
                playerModel = new PlayerModel("", "", PlayerEnvironment.DEFAULT_RACE_TIME, 1, 5, 5, 5);
                PlayerRepository.I.Save(playerModel);
            }

            _presenter.Setup(playerModel.Acceleration, playerModel.Fastest, playerModel.InitialVelocity);
        }

        public void Close()
        {
            _presenter.Close();
        }

        public void Open()
        {
            _presenter.Open();
        }
    }
}