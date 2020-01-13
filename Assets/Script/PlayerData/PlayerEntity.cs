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
        string raceTime = "";

        public string RaceTime
        {
            get { return raceTime; }
        }

        public PlayerEntity(PlayerModel model)
        {
            id = model.ID;
            userID = model.UserID;
        }
    }
}