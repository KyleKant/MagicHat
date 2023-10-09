using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private string saveFile;
    private FileStream fileStream;
    public PlayerDataList ReadFile(string fileName)
    {
#pragma warning disable IDE0090 // Use 'new(...)'
        PlayerDataList playerDataList = new PlayerDataList();
#pragma warning restore IDE0090 // Use 'new(...)'
        saveFile = Application.persistentDataPath + "/" + fileName;
        if (File.Exists(saveFile) && PlayerPrefs.HasKey("playerDataKey"))
        {
            byte[] savedKey = System.Convert.FromBase64String(PlayerPrefs.GetString("playerDataKey"));
            fileStream = new FileStream(saveFile, FileMode.Open, FileAccess.Read);
            Aes oAes = Aes.Create();
            byte[] outputIV = new byte[oAes.IV.Length];
            fileStream.Read(outputIV, 0, outputIV.Length);
#pragma warning disable IDE0090 // Use 'new(...)'
            CryptoStream oCryptoStream = new CryptoStream(fileStream, oAes.CreateDecryptor(savedKey, outputIV), CryptoStreamMode.Read);
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning disable IDE0090 // Use 'new(...)'
            StreamReader reader = new StreamReader(oCryptoStream);
#pragma warning restore IDE0090 // Use 'new(...)'
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
        string playerDataKey = System.Convert.ToBase64String(savedKey);
        PlayerPrefs.SetString("playerDataKey", playerDataKey);
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
#pragma warning disable IDE0090 // Use 'new(...)'
        CryptoStream iCryptoStream = new CryptoStream(fileStream, iAes.CreateEncryptor(iAes.Key, iAes.IV), CryptoStreamMode.Write);
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning disable IDE0090 // Use 'new(...)'
        StreamWriter writer = new StreamWriter(iCryptoStream);
#pragma warning restore IDE0090 // Use 'new(...)'
        string writtenText = JsonUtility.ToJson(playerDataList);
        writer.Write(writtenText);
        writer.Close();
        iCryptoStream.Close();
        fileStream.Close();
    }
}
