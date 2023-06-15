using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public SaveData(List<string> _objInfo)
    {
        objInfo = _objInfo;
    }

    public List<string> objInfo;

    //public List<string> ObjInfo { get { return objInfo; } }

}

public static class DataManager
{
    private static string savePath = Application.persistentDataPath + "/ScreenShotData/";

    public static void Save(SaveData saveData, string saveFileName)
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        string saveJson = JsonUtility.ToJson(saveData);

        string saveFilePath = savePath + saveFileName + ".json";
        File.WriteAllText(saveFilePath, saveJson);
        Debug.Log("Save Success: " + saveFilePath);
    }

    public static SaveData Load(string saveFileName)
    {
        string saveFilePath = savePath + saveFileName + ".json";

        if (!File.Exists(saveFilePath))
        {
            Debug.LogError("No such saveFile exists");
            return null;
        }

        string saveFile = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveFile);
        return saveData;
    }
}


