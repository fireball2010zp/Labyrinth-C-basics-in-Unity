using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Maze
{
    public class StreamData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "StreamData.xyz");

        public void SaveData(PlayerData player)
        {
            using(StreamWriter _writer = new StreamWriter(SavePath))
            {
                _writer.WriteLine(player.PlayerName);
                _writer.WriteLine(player.PlayerHealth);
                _writer.WriteLine(player.PlayerPosition);
            }
        }

        public PlayerData Load()
        {
            PlayerData result = new PlayerData();

            if (!File.Exists(SavePath))
            {
                Debug.Log("FILE NOT EXIST!");
                return result;
            }

            using (StreamReader _reader = new StreamReader(SavePath))
            {
                result.PlayerName = _reader.ReadLine();
                result.PlayerHealth = Convert.ToInt32(_reader.ReadLine());
                // result.PlayerPosition = _reader.ReadLine();
            }

            return result;

        }
    }
}



