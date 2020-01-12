using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class ResultPresenter : RootPresenter
    {
        [SerializeField]
        ResultView _view = null;
        
        public void RegisterGoTitle(Action onAction)
        {
            _view.GoTitle.onClick.RemoveAllListeners();
            _view.GoTitle.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}