using System;
using UnityEngine;

namespace SuperSport
{
    public class StageSelectPresenter : MonoBehaviour
    {
        [SerializeField]
        StageSelectView _view = null;

        public void ActiveRaceSelectButtons(int level)
        {
            if (level <= 0)
            {
                level = 0;
            }

            for (int i = 0; i < _view.Buttons.Count; i++)
            {
                var button = _view.Buttons[i];
                button.interactable = level >= i;
            }
        }
        
        public void RegisterRaceSelectButton(Action<int> onAction)
        {
            for (int i = 0; i < _view.Buttons.Count; i++)
            {
                var button = _view.Buttons[i];
                int number = i;
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() =>
                {
                    onAction?.Invoke(number);
                });
            }
        }
        
        public void RegisterCloseButton(Action onAction)
        {
            _view.Close.onClick.RemoveAllListeners();
            _view.Close.onClick.AddListener(() => { onAction?.Invoke(); });
        }

        public void SetActive(bool enable)
        {
            _view.SelectRace.SetActive(enable);
        }
    }
}