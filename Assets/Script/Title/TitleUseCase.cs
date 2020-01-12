using System;
using Framework;

namespace SuperSport
{
    public class TitleUseCase : IUseCase
    {
        readonly TitlePresenter _presenter;

        public TitleUseCase(TitlePresenter presenter, Action onChangeRace)
        {
            _presenter = presenter;
            _presenter.RegisterGoRaceButton(onChangeRace);
        }
    }
}