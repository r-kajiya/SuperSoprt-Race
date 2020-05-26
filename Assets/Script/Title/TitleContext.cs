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

        [SerializeField]
        RegistPresenter _registPresenter = null;
        
        TitleUseCase _titleUseCase;
        RankingUseCase _rankingUseCase;
        RegistUseCase _registUseCase;

        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            CameraManager.I.RequestCameraState(CameraStateType.Title);
            
            _rankingUseCase = new RankingUseCase(_rankingPresenter);
            _registUseCase = new RegistUseCase(_registPresenter);
            _rankingUseCase.Close();
            _registUseCase.Close();
            
            _titleUseCase = new TitleUseCase(titlePresenter, OnChangeRace, OpenRanking);

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
            if (raceType == RaceType.Rank)
            {
                if (_registUseCase.CanOpen())
                {
                    _registUseCase.Open(() =>
                    {
                        ChangeContext(SystemContexts["RaceContext"], new TitleContextContainer(raceType));
                    });
                }
                else
                {
                    ChangeContext(SystemContexts["RaceContext"], new TitleContextContainer(raceType));
                }
            }
            else
            {
                ChangeContext(SystemContexts["RaceContext"], new TitleContextContainer(raceType));   
            }
        }

        void OpenRanking()
        {
            _rankingUseCase.Open();
        }
    }
}


