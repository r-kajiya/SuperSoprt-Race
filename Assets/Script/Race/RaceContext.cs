using Framework;
using System.Collections;
using UnityEngine;

namespace SuperSport
{
    public class RaceContext : SystemContext
    {
        RacePresenter racePresenter {
            get { return RootPresenter as RacePresenter;
            }
        }

        RaceUseCase _useCase;

        [SerializeField]
        RacePlayer _racePlayer = null;
        
        [SerializeField]
        RaceGoal _raceGoal = null;
        
        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            _useCase = new RaceUseCase(racePresenter, _racePlayer, _raceGoal, OnChangeResult);
            CameraManager.I.RequestCameraState(CameraStateType.Race);

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
        
        void OnChangeTitle()
        {
            ChangeContext(SystemContexts["TitleContext"]);
        }
        
        void OnChangeResult()
        {
            ChangeContext(SystemContexts["ResultContext"]);
        }
    }
}