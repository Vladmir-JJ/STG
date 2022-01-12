using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
namespace JJ.STG.Main
{
    public static class SaveSystem
    {
        public static void SaveGame(int timesPlayed, List<int> scoreList)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/save.stg";
            FileStream stream = new FileStream(path, FileMode.Create);
            GameData data = new GameData(timesPlayed, scoreList);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static GameData LoadData()
        {
            string path = Application.persistentDataPath + "/save.stg";
            if(File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                GameData data = formatter.Deserialize(stream) as GameData;
                stream.Close();
                return data;                
            }
            else
            {
                return null;
            }
        }
    }
}

