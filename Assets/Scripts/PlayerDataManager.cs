using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private string saveFile;
    private FileStream fileStream;
    private void Awake()
    {
    }
    public PlayerData ReadFile(string fileName)
    {
        PlayerData gameData = new PlayerData();
        saveFile = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(saveFile) && PlayerPrefs.HasKey("key"))
        {
            byte[] savedKey = System.Convert.FromBase64String(PlayerPrefs.GetString("key"));
            fileStream = new FileStream(saveFile, FileMode.Open, FileAccess.Read);
            Aes oAes = Aes.Create();
            byte[] outputIV = new byte[oAes.IV.Length];
            fileStream.Read(outputIV, 0, outputIV.Length);
            CryptoStream oCryptoStream = new CryptoStream(fileStream, oAes.CreateDecryptor(savedKey, outputIV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(oCryptoStream);
            string readText = reader.ReadToEnd();
            reader.Close();
            gameData = JsonUtility.FromJson<PlayerData>(readText);
        }
        return gameData;
    }
    public void WriteFile(string fileName, PlayerData gameData)
    {
        saveFile = Application.persistentDataPath + "/" + fileName;
        Aes iAes = Aes.Create();
        byte[] savedKey = iAes.Key;
        string key = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("key", key);
        fileStream = new FileStream(saveFile, FileMode.Create);
        byte[] inputIV = iAes.IV;
        fileStream.Write(inputIV, 0, inputIV.Length);
        CryptoStream iCryptoStream = new CryptoStream(fileStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(iCryptoStream);
        string writtenText = JsonUtility.ToJson(gameData);
        writer.Write(writtenText);
        writer.Close();
        iCryptoStream.Close();
        fileStream.Close();
    }
}
