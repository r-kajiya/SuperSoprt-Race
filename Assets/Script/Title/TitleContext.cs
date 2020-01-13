using System.Collections;
using Framework;
using UnityEngine;

namespace SuperSport
{
    public class TitleContext : SystemContext
    {
        TitlePresenter titlePresenter {
            get { return RootPresenter as TitlePresenter;
            }
        }

        [SerializeField]
        RankingPresenter _rankingPresenter = null;

        TitleUseCase _titleUseCase;
        RankingUseCase _rankingUseCase;
        
        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            CameraManager.I.RequestCameraState(CameraStateType.Title);
            _rankingUseCase = new RankingUseCase(_rankingPresenter);
            _titleUseCase = new TitleUseCase(titlePresenter, OnChangeRace, () =>
            {
                _rankingUseCase.Open();
            });

            yield break;
        }

        protected override IEnumerator DoLoad(SystemContextContainer container)
        {
            yield break;
        }

        protected override IEnumerator DoLoaded(SystemContextContainer container)
        {
            yield break;
        }

        protected override IEnumerator DoPreUnload()
        {
            yield break;
        }

        protected override IEnumerator DoUnload()
        {
            yield break;
        }

        protected override IEnumerator DoUnloaded()
        {
            yield break;
        }
        
        void OnChangeRace(RaceType raceType)
        {
            ChangeContext(SystemContexts["RaceContext"], new TitleContextContainer(raceType));
        }
        
        void OnChangeRanking()
        {
            // ChangeContext(SystemContexts["RaceContext"]);
        }
    }
}


