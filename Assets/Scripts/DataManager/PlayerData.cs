using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int playerScore;
    public int highScore;
    public string dateTime;
}
[Serializable]
public class PlayerDataList
{
    public List<PlayerData> PlayerDatas = new();
}
