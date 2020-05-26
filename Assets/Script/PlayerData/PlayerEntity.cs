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

        public PlayerEntity(PlayerModel model)
        {
            id = model.ID;
            userID = model.UserID;
            userName = model.UserName;
            raceTime = model.RaceTime;
            raceLevel = model.RaceLevel;
        }
    }
}