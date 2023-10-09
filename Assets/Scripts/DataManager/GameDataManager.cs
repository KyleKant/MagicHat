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
#pragma warning disable IDE0090 // Use 'new(...)'
        GameData gameData = new GameData();
#pragma warning restore IDE0090 // Use 'new(...)'
        savedFile = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(savedFile) && PlayerPrefs.HasKey("gameDataKey"))
        {
            byte[] savedKey = System.Convert.FromBase64String(PlayerPrefs.GetString("gameDataKey"));
            fileStream = new FileStream(savedFile, FileMode.Open, FileAccess.Read);
            Aes oAes = Aes.Create();
            byte[] outputIV = new byte[oAes.IV.Length];
            fileStream.Read(outputIV, 0, outputIV.Length);
#pragma warning disable IDE0090 // Use 'new(...)'
            CryptoStream oCryptoStream = new CryptoStream(fileStream, oAes.CreateDecryptor(savedKey, outputIV), CryptoStreamMode.Read);
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning disable IDE0090 // Use 'new(...)'
            StreamReader reader = new StreamReader(oCryptoStream);
#pragma warning restore IDE0090 // Use 'new(...)'
            JsonReader jsonReader = new JsonTextReader(reader);
            //string readText = reader.ReadToEnd();
#pragma warning disable IDE0090 // Use 'new(...)'
            JsonSerializer serializer = new JsonSerializer();
#pragma warning restore IDE0090 // Use 'new(...)'
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
        string gameDataKey = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("gameDataKey", gameDataKey);
        fileStream = new FileStream(savedFile, FileMode.Create);
        byte[] inputIV = iAes.IV;
        fileStream.Write(inputIV, 0, inputIV.Length);
#pragma warning disable IDE0090 // Use 'new(...)'
        CryptoStream iCryptoStream = new CryptoStream(fileStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning disable IDE0090 // Use 'new(...)'
        StreamWriter writer = new StreamWriter(iCryptoStream);
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning disable IDE0090 // Use 'new(...)'
        JsonSerializer serializer = new JsonSerializer();
#pragma warning restore IDE0090 // Use 'new(...)'
        serializer.Serialize(writer, gameData);
        //string writtenText = JsonUtility.ToJson(gameData);
        //writer.Write(writtenText);
        writer.Close();
        iCryptoStream.Close();
        fileStream.Close();
    }
}
