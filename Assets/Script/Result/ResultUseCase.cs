using System;
using Framework;

namespace SuperSport
{
    public class ResultUseCase : IUseCase
    {
        readonly ResultPresenter _presenter;
        readonly Action _onChangeTitle;

        public ResultUseCase(ResultPresenter presenter,Action onChangeTitle)
        {
            _presenter = presenter;
            _onChangeTitle = onChangeTitle;
            _presenter.RegisterGoTitle(OnChangeTitle);
        }

        void OnChangeTitle()
        {
            _onChangeTitle?.Invoke();
        }
    }
}