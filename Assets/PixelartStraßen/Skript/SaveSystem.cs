/*using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;
using UnityEditor.Experimental.RestService;
using System;

public static class SaveSystem
{

    public static void SaveGame(resourceController resource)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(resource);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/game";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }


    }


}
*/