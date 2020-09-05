using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    [Serializable]
    public class RaceEntity : IEntity
    {
        [SerializeField, HideInInspector]
        int id = -1;

        public int ID
        {
            get { return id; }
        }

        [SerializeField, HideInInspector]
        int raceLevel = -1;

        public int RaceLevel
        {
            get { return raceLevel; }
        }
        
        [SerializeField, HideInInspector]
        int forceB = -1;

        public int ForceB
        {
            get { return forceB; }
        }
        
        [SerializeField, HideInInspector]
        int forceC = -1;

        public int ForceC
        {
            get { return forceC; }
        }
        
        [SerializeField, HideInInspector]
        int forceD = -1;

        public int ForceD
        {
            get { return forceD; }
        }
        
        [SerializeField, HideInInspector]
        int forceE = -1;

        public int ForceE
        {
            get { return forceE; }
        }
        
        [SerializeField, HideInInspector]
        int boostValueB = -1;

        public int BoostValueB
        {
            get { return boostValueB; }
        }
        
        [SerializeField, HideInInspector]
        int boostTimingB = -1;

        public int BoostTimingB
        {
            get { return boostTimingB; }
        }
        
        [SerializeField, HideInInspector]
        int boostValueC = -1;

        public int BoostValueC
        {
            get { return boostValueC; }
        }
        
        [SerializeField, HideInInspector]
        int boostTimingC = -1;

        public int BoostTimingC
        {
            get { return boostTimingC; }
        }
        
        [SerializeField, HideInInspector]
        int boostValueD = -1;

        public int BoostValueD
        {
            get { return boostValueD; }
        }
        
        [SerializeField, HideInInspector]
        int boostTimingD = -1;

        public int BoostTimingD
        {
            get { return boostTimingD; }
        }
        
        [SerializeField, HideInInspector]
        int boostValueE = -1;

        public int BoostValueE
        {
            get { return boostValueE; }
        }
        
        [SerializeField, HideInInspector]
        int boostTimingE = -1;

        public int BoostTimingE
        {
            get { return boostTimingE; }
        }

        public RaceEntity(RaceModel model)
        {
            id = model.ID;
            raceLevel = model.RaceLevel;
            forceB = (int)model.ForceB * 10;
            forceC = (int)model.ForceC * 10;
            forceD = (int)model.ForceD * 10;
            forceE = (int)model.ForceE * 10;
            boostValueB = (int)model.BoostValueB;
            boostTimingB = model.BoostTimingB;
            boostValueC = (int)model.BoostValueC;
            boostTimingC = model.BoostTimingC;
            boostValueD = (int)model.BoostValueD;
            boostTimingD = model.BoostTimingD;
            boostValueE = (int)model.BoostValueE;
            boostTimingE = model.BoostTimingE;
        }
    }
}