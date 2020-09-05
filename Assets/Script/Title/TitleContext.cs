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
        
        TitleUseCase _titleUseCase;

        [SerializeField]
        StageSelectPresenter _stageSelectPresenter = null;

        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            CameraManager.I.RequestCameraState(CameraStateType.Title);
            
            _titleUseCase = new TitleUseCase(titlePresenter, _stageSelectPresenter, OnChangeRace);

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
        
        void OnChangeRace(int selectRace)
        {
            ChangeContext(SystemContexts["RaceContext"], new TitleContextContainer(selectRace));
        }
    }
}


