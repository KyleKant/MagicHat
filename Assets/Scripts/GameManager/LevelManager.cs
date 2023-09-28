using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameData gameData;
    public void SelectLevel(string level)
    {
        gameData = new GameData();
        switch (level)
        {
            case "Easy":
                gameData.Level = GameLevel.Easy;
                break;
            case "Normal":
                gameData.Level = GameLevel.Normal;
                break;
            case "Hard":
                gameData.Level = GameLevel.Hard;
                break;
        }
    }
    public GameData GetGameData()
    {
        return gameData;
    }
}
