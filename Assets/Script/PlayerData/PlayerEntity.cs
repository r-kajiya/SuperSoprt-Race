using System;
using UnityEngine;
using Framework;

namespace SuperSport
{
    [Serializable]
    public class PlayerEntity : IEntity
    {
        [SerializeField, HideInInspector]
        int id = -1;

        public int ID
        {
            get { return id; }
        }

        [SerializeField, HideInInspector]
        string userID = "";

        public string UserID
        {
            get { return userID; }
        }
        
        [SerializeField, HideInInspector]
        string userName = "";

        public string UserName
        {
            get { return userName; }
        }
        
        [SerializeField, HideInInspector]
        float raceTime = PlayerEnvironment.DEFAULT_RACE_TIME;

        public float RaceTime
        {
            get { return raceTime; }
        }
        
        [SerializeField, HideInInspector]
        int raceLevel = 0;

        public int RaceLevel
        {
            get { return raceLevel; }
        }
        
        [SerializeField, HideInInspector]
        int acceleration = 0;

        public int Acceleration
        {
            get { return acceleration; }
        }
        
        [SerializeField, HideInInspector]
        int fastest = 0;

        public int Fastest
        {
            get { return fastest; }
        }
        
        [SerializeField, HideInInspector]
        int initialVelocity = 0;

        public int InitialVelocity
        {
            get { return initialVelocity; }
        }

        public PlayerEntity(PlayerModel model)
        {
            id = model.ID;
            userID = model.UserID;
            userName = model.UserName;
            raceTime = model.RaceTime;
            raceLevel = model.RaceLevel;
            acceleration = model.Acceleration;
            fastest = model.Fastest;
            initialVelocity = model.InitialVelocity;
        }
    }
}