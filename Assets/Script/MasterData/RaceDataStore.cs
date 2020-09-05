using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Framework;
using Network = Framework.Network;

namespace SuperSport
{
    public class RaceDataStore : IDataStore<RaceModel>
    {
        const string FILE_PATH = "Master/data_race.json";
        
        [Serializable]
        class Entities
        {
            public RaceEntity[] Values = null;
        }

        public void Save(RaceModel model) { }

        public void SaveList(List<RaceModel> models) { }

        public Dictionary<int, RaceModel> Load()
        {
            string assetsPath = $"{Application.streamingAssetsPath}/{FILE_PATH}";
            string json = "";
#if UNITY_ANDROID && !UNITY_EDITOR
            WWW www = new WWW(assetsPath);
            while (!www.isDone) { }
            string txtBuffer = string.Empty;
            TextReader txtReader = new StringReader(www.text);
            string description = string.Empty;
            while ((txtBuffer = txtReader.ReadLine()) != null)
            {
                description = description + txtBuffer;
            }
            json = description;
#else
            
            FileInfo info = new FileInfo(assetsPath);
            StreamReader reader = new StreamReader(info.OpenRead());
            json = reader.ReadToEnd();
            reader.Close();
#endif
            
            if (string.IsNullOrEmpty(json))
            {
                DebugLog.Warning(FILE_PATH + "が存在していますがファイルの中身がありません");
                return new Dictionary<int, RaceModel>();   
            }

            var map = new Dictionary<int, RaceModel>();
            var parse = JsonUtility.FromJson<Entities>(json);

            foreach (var entity in parse.Values)
            {
                RaceModel model = new RaceModel(
                    entity.RaceLevel,
                    entity.ForceB * 0.1f,
                    entity.ForceC * 0.1f,
                    entity.ForceD * 0.1f,
                    entity.ForceE * 0.1f,
                    entity.BoostValueB,
                    entity.BoostTimingB,
                    entity.BoostValueC,
                    entity.BoostTimingC,
                    entity.BoostValueD,
                    entity.BoostTimingD,
                    entity.BoostValueE,
                    entity.BoostTimingE);

                map.Add(model.ID, model);
            }

            return map;
        }
    }
}

