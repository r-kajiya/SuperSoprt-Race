using System;
using UnityEngine;

namespace SuperSport
{
    public class RaceGoal : MonoBehaviour
    {
        Action<bool> _onEnter;
        
        public void RegisterEnter(Action<bool> onEnter)
        {
            _onEnter = onEnter;
        }
        
        void OnTriggerEnter(Collider other)
        {
            _onEnter?.Invoke(true);
        }
    }
}