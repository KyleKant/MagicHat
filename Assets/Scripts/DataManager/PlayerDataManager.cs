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
    public PlayerDataList ReadFile(string fileName)
    {
        PlayerDataList playerDataList = new PlayerDataList();
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
            playerDataList = JsonUtility.FromJson<PlayerDataList>(readText);
        }
        return playerDataList;
    }
    public void WriteFile(string fileName, PlayerDataList playerDataList)
    {
        saveFile = Application.persistentDataPath + "/" + fileName;
        Aes iAes = Aes.Create();
        byte[] savedKey = iAes.Key;
        string key = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("key", key);
        //if (File.Exists(saveFile))
        //{
        //    fileStream = new FileStream(saveFile, FileMode.Append, FileAccess.Write);
        //}
        //else
        //{
        //    fileStream = new FileStream(saveFile, FileMode.Create);
        //}
        fileStream = new FileStream(saveFile, FileMode.Create);
        byte[] inputIV = iAes.IV;
        fileStream.Write(inputIV, 0, inputIV.Length);
        CryptoStream iCryptoStream = new CryptoStream(fileStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(iCryptoStream);
        string writtenText = JsonUtility.ToJson(playerDataList);
        writer.Write(writtenText);
        writer.Close();
        iCryptoStream.Close();
        fileStream.Close();
    }
}
