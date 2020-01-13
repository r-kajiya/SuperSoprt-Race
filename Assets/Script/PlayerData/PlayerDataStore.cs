using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace SuperSport
{
    public class PlayerDataStore : IDataStore<PlayerModel>
    {
        const string FILE_PATH = "player.json";

        [Serializable]
        private class Entities
        {
            public PlayerEntity[] Player = null;

            public static Entities Convert(Dictionary<int, PlayerModel> map)
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
            
            string json = JsonUtility.ToJson (Entities.Convert(map));
            SavePlayerData(json);
        }

        public void SaveList(List<PlayerModel> models)
        {
            Dictionary<int, PlayerModel> map = Load();
            
            foreach (var model in models)
            {
                if (map.ContainsKey(model.ID))
                {
                    map[model.ID] = model;
                }
                else
                {
                    map.Add(model.ID, model);
                }
            }
            
            string json = JsonUtility.ToJson (Entities.Convert(map));
            SavePlayerData(json);
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
                PlayerModel model = new PlayerModel(entity.UserID, entity.UserName, entity.RaceTime);

                map.Add(model.ID, model);
            }

            return map;
        }

        void SavePlayerData(string json)
        {
            string filePath = $"{Application.persistentDataPath}/{FILE_PATH}";
            
            StreamWriter writer = File.CreateText(filePath);
            writer.Write(json);
            writer.Close();
            
            DebugLog.Normal(this.GetType() + "を保存しました。" + filePath);
        }

        bool Exists()
        {
            return File.Exists($"{Application.persistentDataPath}/{FILE_PATH}");
        }
        
    }
}

