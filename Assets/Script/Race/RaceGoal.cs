using System;
using UnityEngine;

namespace SuperSport
{
    public class RaceGoal : MonoBehaviour
    {
        Action _onEnter;
        
        public void RegisterEnter(Action onEnter)
        {
            _onEnter = onEnter;
        }
        
        void OnTriggerEnter(Collider other)
        {
            _onEnter?.Invoke();
        }
    }
}