using System.Runtime.Serialization;

[DataContract(Name = "Player Data", Namespace = "Player Score Data")]
public class PlayerData
{
    [DataMember]
    public int playerScore;
    [DataMember]
    public int highScore;
}
