using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using UnityEngine;
[DataContract(Name = "Player", Namespace = "PlayerScore")]
public class Player : IExtensibleDataObject
{
    [DataMember()]
    public int playerScore;
    [DataMember()]
    public int highScore;

    private ExtensionDataObject extensionData_Value;
    public ExtensionDataObject ExtensionData
    {
        get
        {
            return extensionData_Value;
        }
        set
        {
            extensionData_Value = value;
        }
    }

}
public class DataStorageController : MonoBehaviour
{
    public void WriteObject(string fileName, int playerScore, int highScore)
    {
        Debug.Log($"Create a Player object and serializing it at path: {Application.persistentDataPath}.");
        Player player = new();
        player.playerScore = playerScore;
        player.highScore = highScore;
        FileStream writer = new(Application.persistentDataPath + "/" + fileName, FileMode.Create);
        DataContractSerializer dataContractSerializer = new(typeof(Player));
        dataContractSerializer.WriteObject(writer, player);
        writer.Seek(0, SeekOrigin.Begin);

        writer.Close();
    }
    public Player ReadObject(string fileName)
    {
        Debug.Log("Deserializing an instance of the object");
        FileStream fileStream = new(Application.persistentDataPath + "/" + fileName, FileMode.Open);
        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
        DataContractSerializer dataContractSerializer = new(typeof(Player));

        // Deserialize the data and read it from the instance
        Player deserializedPlayer = (Player)dataContractSerializer.ReadObject(reader, true);
        reader.Close();
        fileStream.Close();
        Debug.Log($"playerScore: {deserializedPlayer.playerScore}, highScore: {deserializedPlayer.highScore}");
        return deserializedPlayer;
    }
}
