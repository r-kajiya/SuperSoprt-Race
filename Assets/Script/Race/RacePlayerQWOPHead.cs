using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperSport
{
    public class RacePlayerQWOPHead : MonoBehaviour
    {
        Action<bool> _onTouch;
        bool _isTouch;
        
        public void Setup(Action<bool> onTouch)
        {
            _isTouch = false;
            _onTouch = onTouch;
        }
        
        void OnCollisionEnter(Collision collision)
        {
            if (!collision.transform.name.Contains("Ground"))
            {
                return;
            }
            
            if (_isTouch)
            {
                return;
            }
            _onTouch?.Invoke(false);
            _isTouch = true;
        }
    }
}


