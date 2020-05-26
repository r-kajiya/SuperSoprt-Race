using System;
using UnityEngine;

namespace SuperSport
{
    public class RegistPresenter : MonoBehaviour
    {
        [SerializeField]
        RegistView _view = null;

        public void RegisterCloseButton(Action onAction)
        {
            _view.Close.onClick.RemoveAllListeners();
            _view.Close.onClick.AddListener(() => { onAction?.Invoke(); });
        }
        
        public void RegisterDecisionButton(Action<string> onAction)
        {
            _view.Decision.onClick.RemoveAllListeners();
            _view.Decision.onClick.AddListener(() => { onAction?.Invoke(_view.NameText.text); });
        }
        
        public void Open()
        {
            _view.SetActive(true);
        }

        public void Close()
        {
            _view.SetActive(false);   
        }
    }
}