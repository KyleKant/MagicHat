using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameData gameData;
    public void SelectLevel(int levelNum)
    {
        gameData = new GameData();
        switch (levelNum)
        {
            case 0:
                gameData.Level = GameLevel.Easy;
                break;
            case 1:
                gameData.Level = GameLevel.Normal;
                break;
            case 2:
                gameData.Level = GameLevel.Hard;
                break;
        }
    }
    public GameData GetGameData()
    {
        Debug.Log(gameData.Level);
        return gameData;
    }
}
