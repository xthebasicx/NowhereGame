using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SaveGame(PlayerHealth playerData)
    {
        SaveData saveData = new SaveData(playerData);
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath, json);
        Debug.Log("Save file : " + json + " Save path : " + savePath);
    }
    public static SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            String json = File.ReadAllText(savePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Load file" + json);
            return saveData;
        }
        else
        {
            Debug.Log("Save file ot found");
            return null;
        }
    }
}
