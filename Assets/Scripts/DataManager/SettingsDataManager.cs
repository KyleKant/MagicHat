using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class SettingsDataManager : MonoBehaviour
{
    public SettingsData ReadSettingsData(string fileName)
    {
        string savedFile = Application.persistentDataPath + "/" + fileName;
        FileStream fileStream = new(savedFile, FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new(fileStream);
        JsonReader jsonReader = new JsonTextReader(streamReader);
        JsonSerializer serializer = new();
        SettingsData settingsData = serializer.Deserialize<SettingsData>(jsonReader);
        jsonReader.Close();
        streamReader.Close();
        fileStream.Close();
        return settingsData;
    }
    public void WriteSettingsData(string fileName, SettingsData data)
    {
        string savedFile = Application.persistentDataPath + "/" + fileName;
        FileStream fileStream = new(savedFile, FileMode.Create);
        StreamWriter streamWriter = new(fileStream);
        JsonSerializer serializer = new();
        serializer.Serialize(streamWriter, data);
        streamWriter.Write(data);
        streamWriter.Close();
        fileStream.Close();
    }
    public bool CheckFileIsExist(string fileName)
    {
        string filePath = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(filePath))
        {
            return true;
        }
        return false;
    }
}
