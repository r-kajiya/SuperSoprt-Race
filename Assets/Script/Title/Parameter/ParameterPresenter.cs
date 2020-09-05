using System;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class ParameterPresenter : MonoBehaviour
    {
        [SerializeField]
        ParameterView _view = null;

        const int MIN = 5;
        const int MAX = 295;

        public void Setup(int acceleration, int fastest, int initialVelocity)
        {
            int accelerationRight = Mathf.Min(MAX, Mathf.Max(MIN, acceleration)) ;
            accelerationRight = 300 - accelerationRight;
            _view.AccelerationBarTransform.offsetMax = new Vector2(-accelerationRight, _view.AccelerationBarTransform.offsetMax.y);
            
            int fastestRight = Mathf.Min(MAX, Mathf.Max(MIN, fastest)) ;
            fastestRight = 300 - fastestRight;
            _view.FastestBarTransform.offsetMax = new Vector2(-fastestRight, _view.FastestBarTransform.offsetMax.y);
            
            int initialVelocityRight = Mathf.Min(MAX, Mathf.Max(MIN, initialVelocity)) ;
            initialVelocityRight = 300 - initialVelocityRight;
            _view.InitialVelocityBarTransform.offsetMax = new Vector2(-initialVelocityRight, _view.InitialVelocityBarTransform.offsetMax.y);
        }

        public void Open()
        {
            _view.Root.SetActive(true);
        }

        public void Close()
        {
            _view.Root.SetActive(false);
        }
        
        public void RegisterCloseButton(Action onAction)
        {
            _view.Close.onClick.RemoveAllListeners();
            _view.Close.onClick.AddListener(() => { onAction?.Invoke(); });
        }
    }
}