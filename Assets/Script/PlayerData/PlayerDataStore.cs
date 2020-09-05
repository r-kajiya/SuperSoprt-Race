using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using Network = Framework.Network;

namespace SuperSport
{
    public class PlayerDataStore : IDataStore<PlayerModel>
    {
        const string FILE_PATH = "player.json";
        const string DATABASE_KEY = "Users";

        [Serializable]
        class Entities
        {
            public PlayerEntity[] Player = null;

            public static Entities ConvertFromMap(Dictionary<int, PlayerModel> map)
            {
                Entities entities = new Entities();
                entities.Player = new PlayerEntity[map.Count];

                int index = 0;
                foreach (var model in map.Values)
                {
                    entities.Player[index] = new PlayerEntity(model);
                    index++;
                }

                return entities;
            }
            
            public static Entities ConvertFromJson(string json)
            {
                Entities entities =  JsonUtility.FromJson<Entities>(json);

                return entities;
            }
        }

        public void Save(PlayerModel model)
        {
            Dictionary<int, PlayerModel> map = Load();
            
            if (map.ContainsKey(model.ID))
            {
                map[model.ID] = model;
            }
            else
            {
                map.Add(model.ID, model);
            }

            string json = JsonUtility.ToJson (Entities.ConvertFromMap(map));
            SavePlayerData(json);

            if (map[model.ID].RaceLevel == PlayerEnvironment.RANK_RACE_LEVEL)
            {
                CommitPlayerData(map[model.ID].UserID, json);
            }
        }

        public void SaveList(List<PlayerModel> models)
        {
            DebugLog.Warning("PlayerDataはSaveListを使用できません");
        }

        public Dictionary<int, PlayerModel> Load()
        {
            if (!Exists())
            {
                DebugLog.Normal(FILE_PATH + "が存在していません");
                return new Dictionary<int, PlayerModel>();
            }
            
            FileInfo info = new FileInfo($"{Application.persistentDataPath}/{FILE_PATH}");
            StreamReader reader = new StreamReader(info.OpenRead());
            string json = reader.ReadToEnd();
            reader.Close();
            
            if (string.IsNullOrEmpty(json))
            {
                DebugLog.Normal(FILE_PATH + "が存在していますがファイルの中身がありません");
                return new Dictionary<int, PlayerModel>();   
            }

            var map = new Dictionary<int, PlayerModel>();
            var parse = JsonUtility.FromJson<Entities>(json);

            foreach (var entity in parse.Player)
            {
                PlayerModel model = new PlayerModel(entity.UserID, entity.UserName, entity.RaceTime, entity.RaceLevel, entity.Acceleration, entity.Fastest, entity.InitialVelocity);

                map.Add(model.ID, model);
            }

            return map;
        }

        public void FetchOrderByFirst(string sortKey, int fetchCount, Action<List<PlayerModel>> onSuccess)
        {
            Action<string> onComplete = json =>
            {
                // var list = ConvertList(Entities.ConvertFromJson(json));
                onSuccess.Invoke(null);
            };
            
            Network.GetOrderByFirst(DATABASE_KEY, sortKey, fetchCount, onComplete, null);
        }

        void SavePlayerData(string json)
        {
            string filePath = $"{Application.persistentDataPath}/{FILE_PATH}";
            
            StreamWriter writer = File.CreateText(filePath);
            writer.Write(json);
            writer.Close();
            
            DebugLog.Normal(this.GetType() + "を保存しました。" + filePath);
        }

        void CommitPlayerData(string userID, string json)
        {
            Network.SetById(DATABASE_KEY, userID, json, null, null);
        }

        bool Exists()
        {
            return File.Exists($"{Application.persistentDataPath}/{FILE_PATH}");
        }

        List<PlayerModel> ConvertList(Entities entities)
        {
            List<PlayerModel> list = new List<PlayerModel>();

            foreach (var entity in entities.Player)
            {
                PlayerModel model = new PlayerModel(entity.UserID, entity.UserName, entity.RaceTime, entity.RaceLevel, entity.Acceleration, entity.Fastest, entity.InitialVelocity);
                list.Add(model);
            }
            
            return list;
        }
        
    }
}

