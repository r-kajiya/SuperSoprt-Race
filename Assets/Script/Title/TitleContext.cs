using System.Collections;
using Framework;

namespace SuperSport
{
    public class TitleContext : SystemContext
    {
        TitlePresenter titlePresenter {
            get { return RootPresenter as TitlePresenter;
            }
        }

        TitleUseCase _useCase;
        
        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            CameraManager.I.RequestCameraState(CameraStateType.Title);
            _useCase = new TitleUseCase(titlePresenter, OnChangeRace);

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
        
        void OnChangeRace()
        {
            ChangeContext(SystemContexts["RaceContext"]);
        }
    }
}


