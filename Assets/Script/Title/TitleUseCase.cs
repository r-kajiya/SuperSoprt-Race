using System;
using Framework;

namespace SuperSport
{
    public class TitleUseCase : IUseCase
    {
        readonly TitlePresenter _presenter;
        Action<RaceType> _onChangeRace;
        Action _onOpenRanking;

        public TitleUseCase(TitlePresenter presenter, Action<RaceType> onChangeRace, Action onOpenRanking)
        {
            _presenter = presenter;
            _onChangeRace = onChangeRace;
            _onOpenRanking = onOpenRanking;
            _presenter.AllDeActive();
            _presenter.RegisterGoQualifyingButton(onChangeRace, true);
            Login();
        }

        void Login()
        {
            if (Network.DidAnonymouslyLoggedIn)
            {
                AfterLogin(PlayerRepository.I.GetOwner());
                return;
            }
            
            Network.SignInAnonymously(userId =>
            {
                PlayerModel model = PlayerRepository.I.GetOwner();

                if (model == null)
                {
                    model = new PlayerModel(userId, "",  PlayerEnvironment.DEFAULT_RACE_TIME, PlayerEnvironment.QUALIFYING_RACE_LEVEL);
                }
                
                PlayerRepository.I.Save(model);

                AfterLogin(model);
            });
        }

        void AfterLogin(PlayerModel playerModel)
        {
            if (playerModel.RaceLevel == PlayerEnvironment.SEMIFINAL_RACE_LEVEL)
            {
                _presenter.RegisterGoSemifinalButton(_onChangeRace, true);
            }
            
            if (playerModel.RaceLevel == PlayerEnvironment.FINAL_RACE_LEVEL)
            {
                _presenter.RegisterGoFinalButton(_onChangeRace, true);
            }
            
            if (playerModel.RaceLevel == PlayerEnvironment.RANK_RACE_LEVEL)
            {
                _presenter.RegisterGoRankButton(_onChangeRace, true);
            }
            
            _presenter.RegisterGoRankingButton(_onOpenRanking, true);
        }
    }
}