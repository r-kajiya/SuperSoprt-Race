using System;
using System.Collections;
using Framework;

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
            _presenter.Win(raceContextContainer.IsWin);
            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _presenter.RegisterGoTitle(OnChangeTitle);
            },WAIT_TIME);
        }

        void OnChangeTitle()
        {
            _onChangeTitle?.Invoke();
        }
    }
}