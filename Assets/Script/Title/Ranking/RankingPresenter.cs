using System;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class RankingPresenter : MonoBehaviour
    {
        [SerializeField]
        RankingView _view = null;

        public void SetRanking(List<PlayerModel> rankingUsers)
        {
            
        }

        public void Open()
        {
            _view.SetActive(true);
        }

        public void Close()
        {
            _view.SetActive(false);   
        }
        
        public void RegisterCloseButton(Action onAction)
        {
            _view.Close.onClick.RemoveAllListeners();
            _view.Close.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}