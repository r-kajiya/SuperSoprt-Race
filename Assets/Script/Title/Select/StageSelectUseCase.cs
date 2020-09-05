using System;
using Framework;

namespace SuperSport
{
    public class StageSelectUseCase : IUseCase
    {
        readonly StageSelectPresenter _presenter;

        public StageSelectUseCase(StageSelectPresenter presenter, Action<int> onChangeRace)
        {
            _presenter = presenter;

            var owner = PlayerRepository.I.GetOwner();

            if (owner == null)
            {
                owner = new PlayerModel();
                PlayerRepository.I.Save(owner);
            }

            _presenter.ActiveRaceSelectButtons(owner.RaceLevel);
            _presenter.RegisterRaceSelectButton(onChangeRace);
            _presenter.RegisterCloseButton(Close);
        }

        public void Open()
        {
            _presenter.SetActive(true);   
        }

        public void Close()
        {
            _presenter.SetActive(false);
        }
    }
}