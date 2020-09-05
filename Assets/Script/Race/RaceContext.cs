using Framework;
using System.Collections;
using System.Collections.Generic;
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
        RacePlayerQWOP _racePlayerQWOP = null;
        
        [SerializeField]
        RaceGoal _raceGoal = null;

        [SerializeField]
        List<GameObject> _stageList;

        protected override IEnumerator DoPreLoad(SystemContextContainer container)
        {
            TitleContextContainer titleContextContainer = container as TitleContextContainer;

            _useCase = new RaceUseCase(racePresenter, _racePlayerQWOP, _raceGoal, OnChangeResult, OnChangeTitle, titleContextContainer.SelectRace);
            
            CameraManager.I.RequestCameraState(CameraStateType.Race);

            for (int i = 0; i < _stageList.Count; i++)
            {
                _stageList[i].SetActive(i == titleContextContainer.SelectRace); 
            }

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
        
        void OnChangeResult(bool isWin, float time, bool isTraining, float length)
        {
            ChangeContext(SystemContexts["ResultContext"], new RaceContextContainer(isWin, time, isTraining, length));
            
            AdManager.I.Show();
        }
    }
}