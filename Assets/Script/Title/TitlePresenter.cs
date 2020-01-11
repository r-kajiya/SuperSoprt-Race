using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitlePresenter : RootPresenter
    {
        [SerializeField]
        TitleView _view = null;

        public void RegisterGoGameButton(Action onAction)
        {
            _view.GoGameButton.onClick.RemoveAllListeners();
            _view.GoGameButton.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}