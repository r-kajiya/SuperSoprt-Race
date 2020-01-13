using System;
using UnityEngine;

namespace SuperSport
{
    public class RaceCharacter : MonoBehaviour, IComparable<RaceCharacter>
    {
        public float Timer { get; set; }

        public int CompareTo(RaceCharacter other)
        {
            return String.Compare(other.name, this.name, StringComparison.Ordinal);
        }
    }
}