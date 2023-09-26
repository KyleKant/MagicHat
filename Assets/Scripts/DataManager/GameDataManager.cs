using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private string savedFile;
    private FileStream fileStream;
    public GameData ReadFile(string fileName)
    {
        GameData gameData = new GameData();
        savedFile = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(savedFile) && PlayerPrefs.HasKey("key"))
        {
            byte[] savedKey = System.Convert.FromBase64String(PlayerPrefs.GetString("key"));
            fileStream = new FileStream(savedFile, FileMode.Open, FileAccess.Read);
            Aes oAes = Aes.Create();
            byte[] outputIV = new byte[oAes.IV.Length];
            fileStream.Read(outputIV, 0, outputIV.Length);
            CryptoStream oCryptoStream = new CryptoStream(fileStream, oAes.CreateDecryptor(savedKey, outputIV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(oCryptoStream);
            JsonReader jsonReader = new JsonTextReader(reader);
            //string readText = reader.ReadToEnd();
            Debug.Log(jsonReader.ToString());
            JsonSerializer serializer = new JsonSerializer();
            gameData = serializer.Deserialize<GameData>(jsonReader);
            reader.Close();
            jsonReader.Close();
            //gameData = JsonUtility.FromJson<GameData>(readText);
        }
        return gameData;
    }
    public void WriteFile(string fileName, GameData gameData)
    {
        savedFile = Application.persistentDataPath + "/" + fileName;
        Aes iAes = Aes.Create();
        byte[] savedKey = iAes.Key;
        string key = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("key", key);
        fileStream = new FileStream(savedFile, FileMode.Create);
        byte[] inputIV = iAes.IV;
        fileStream.Write(inputIV, 0, inputIV.Length);
        CryptoStream iCryptoStream = new CryptoStream(fileStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(iCryptoStream);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(writer, gameData);
        //string writtenText = JsonUtility.ToJson(gameData);
        //writer.Write(writtenText);
        writer.Close();
        iCryptoStream.Close();
        fileStream.Close();
    }
}
