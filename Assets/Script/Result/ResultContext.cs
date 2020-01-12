using Framework;
using System.Collections;
using UnityEngine;

namespace SuperSport
{
    public class ResultContext : SystemContext
    {
        ResultPresenter resultPresenter {
            get { return RootPresenter as ResultPresenter;
            }
        }

        ResultUseCase _useCase;
        
        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            _useCase = new ResultUseCase(resultPresenter, OnChangeTitle);
            CameraManager.I.RequestCameraState(CameraStateType.Sky);

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
    }
}