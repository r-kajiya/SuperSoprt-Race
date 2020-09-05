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

        public void SetTimer(float time)
        {
            _view.TimeText.text = $"{time:F4}";
        }
        
        public void SetLength(float length)
        {
            _view.LengthText.text= $"{length:F5}";
        }

        public void Win(bool win)
        {
            _view.Win.SetActive(win);
            _view.Lose.SetActive(!win);
        }
        
        public void SetTraining(bool isTraining)
        {
            _view.Training.SetActive(isTraining);
            
            if (isTraining)
            {
                _view.Win.SetActive(false);
                _view.Lose.SetActive(false);
            }
        }
    }
}