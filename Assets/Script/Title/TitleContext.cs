using System.Collections;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitleContext : SystemContext
    {
        [SerializeField]
        Transform _uiRoot = null;

        [SerializeField]
        TitlePresenter _presenter = null;
        
        TitleUseCase _useCase;
        
        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
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
        
        void OnChangeAnimalMap()
        {
            ChangeContext(SystemContexts["AnimalMapContext"]);
        }
    }
}


