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
        
        public class User
        {
            public string UserName { get; }
            public float Time { get; }

            public User(string userName, float time)
            {
                UserName = userName;
                Time = time;
            }
        }

        public void SetRanking(List<User> rankingUsers)
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