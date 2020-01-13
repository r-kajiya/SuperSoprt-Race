using System;
using UnityEngine;

namespace SuperSport
{
    public class RaceGoal : MonoBehaviour
    {
        Action<RaceCharacter> _onEnter;
        
        public void RegisterEnter(Action<RaceCharacter> onEnter)
        {
            _onEnter = onEnter;
        }
        
        void OnTriggerEnter(Collider other)
        {
            RaceCharacter raceCharacter = other.GetComponent<RaceCharacter>();
            if (raceCharacter == null)
            {
                return;
            }
            
            _onEnter?.Invoke(raceCharacter);
        }
    }
}