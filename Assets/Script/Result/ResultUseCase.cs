using System;
using System.Collections;
using Framework;

namespace SuperSport
{
    public class ResultUseCase : IUseCase
    {
        readonly ResultPresenter _presenter;
        readonly Action _onChangeTitle;

        public ResultUseCase(ResultPresenter presenter, RaceContextContainer raceContextContainer, Action onChangeTitle)
        {
            _presenter = presenter;
            _onChangeTitle = onChangeTitle;
            _presenter.RegisterGoTitle(null);
            const float waitTime = 2f;
            _presenter.SetTimer(raceContextContainer.Time);
            _presenter.Win(raceContextContainer.IsWin);
            AbsolutelyActiveCorutine.WaitSecondInvoke(() =>
            {
                _presenter.RegisterGoTitle(OnChangeTitle);
            },waitTime);
        }

        void OnChangeTitle()
        {
            _onChangeTitle?.Invoke();
        }
    }
}