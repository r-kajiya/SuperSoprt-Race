using System;
using System.Collections.Generic;
using Framework;

namespace SuperSport
{
    public class RankingUseCase : IUseCase
    {
        readonly RankingPresenter _presenter;

        public RankingUseCase(RankingPresenter presenter)
        {
            _presenter = presenter;
            _presenter.RegisterCloseButton(Close);
        }

        public void Open()
        {
            if (!Network.DidAnonymouslyLoggedIn)
            {
                DebugLog.Error("ログインしていないため、ランキングを開けません");
                return;
            }
            
            PlayerRepository.I.GetRankingList(OnGetRanking);
        }

        public void Close()
        {
            _presenter.Close();
        }

        void OnGetRanking(List<PlayerModel> list)
        {
            _presenter.SetRanking(list);
            _presenter.Open();
        }
    }
}