using System;
using Framework;

namespace SuperSport
{
    public class TitleUseCase : IUseCase
    {
        readonly TitlePresenter _presenter;
        Action<int> _onChangeRace;
        StageSelectUseCase _stageSelectUseCase;

        public TitleUseCase(TitlePresenter presenter, StageSelectPresenter stageSelectPresenter, Action<int> onChangeRace)
        {
            _presenter = presenter;
            _stageSelectUseCase = new StageSelectUseCase(stageSelectPresenter, OnChangeRace);
            _onChangeRace = onChangeRace;
            _presenter.RegisterGoRaceButton(OnOpenStageSelect);
        }

        void OnOpenStageSelect()
        {
            _stageSelectUseCase.Open();
        }

        void OnChangeRace(int selectRace)
        {
            _onChangeRace?.Invoke(selectRace);
        }
    }
}