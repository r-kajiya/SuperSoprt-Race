using System;
using Framework;

namespace SuperSport
{
    public class TitleUseCase : IUseCase
    {
        readonly TitlePresenter _presenter;

        public TitleUseCase(TitlePresenter presenter, Action<RaceType> onChangeRace, Action onOpenRanking)
        {
            _presenter = presenter;
            _presenter.RegisterGoQualifyingButton(onChangeRace);
            _presenter.RegisterGoSemifinalButton(onChangeRace);
            _presenter.RegisterGoFinalButton(onChangeRace);
            _presenter.RegisterGoRankButton(onChangeRace);
            _presenter.RegisterGoRankingButton(onOpenRanking);
            
            // プレイヤーデータの保存
            PlayerRepository.I.GetOwner();
            
            PlayerModel playerModel = PlayerRepository.I.GetOwner();

            if (playerModel == null)
            {
                //PlayerRepository.I.Save(new PlayerModel());
            }
        }
    }
}