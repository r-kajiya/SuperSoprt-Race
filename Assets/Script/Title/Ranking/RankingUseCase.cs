using System;
using Framework;

namespace SuperSport
{
    public class RankingUseCase : IUseCase
    {
        readonly RankingPresenter _presenter;

        public RankingUseCase(RankingPresenter presenter)
        {
            _presenter = presenter;
            _presenter.RegisterCloseButton(() =>
            {
                _presenter.Close();
            });
        }

        public void Open()
        {
            _presenter.Open();
        }
    }
}