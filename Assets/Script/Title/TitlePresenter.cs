using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class TitlePresenter : RootPresenter
    {
        [SerializeField]
        TitleView _view = null;

        public void RegisterGoRaceButton(Action onAction)
        {
            _view.GoRaceButton.onClick.RemoveAllListeners();
            _view.GoRaceButton.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}