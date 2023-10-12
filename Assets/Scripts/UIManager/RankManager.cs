using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private const int RECORD_NUMBER_ON_LEADERBOARD = 10;
    private PlayerManager playerManager;
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0090 // Use 'new(...)'
    private PlayerDataList playerDataList = new PlayerDataList();
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE0044 // Add readonly modifier
    private int numberOfLoops = 0;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        foreach (PlayerData playerData in playerManager.playerDataList.PlayerDatas)
        {
            if (playerData.highScore != 0)
            {
                playerDataList.PlayerDatas.Add(playerData);
            }
        }
    }
    private void Update()
    {
        if (playerManager != null)
        {
            if (playerDataList.PlayerDatas.Count < RECORD_NUMBER_ON_LEADERBOARD)
            {
                for (int i = playerDataList.PlayerDatas.Count - 1; i >= 0; i--)
                {
                    if ((this.gameObject.GetComponentsInChildren<TextMeshProUGUI>().Length / 2f) < playerDataList.PlayerDatas.Count)
                    {
                        if (playerDataList.PlayerDatas[i].highScore != 0)
                        {
                            CreateText($"Score Text {i}", playerDataList.PlayerDatas[i].highScore.ToString());
                            CreateText($"Time Text {i}", playerDataList.PlayerDatas[i].dateTime);
                        }
                    }
                    else break;
                }
            }
            else
            {
                for (int i = playerDataList.PlayerDatas.Count - 1; i >= playerDataList.PlayerDatas.Count - RECORD_NUMBER_ON_LEADERBOARD; i--)
                {
                    if ((this.gameObject.GetComponentsInChildren<TextMeshProUGUI>().Length / 2f) < RECORD_NUMBER_ON_LEADERBOARD)
                    {
                        if (playerDataList.PlayerDatas[i].highScore != 0)
                        {
                            CreateText($"Score Text {i}", playerDataList.PlayerDatas[i].highScore.ToString());
                            CreateText($"Time Text {i}", playerDataList.PlayerDatas[i].dateTime);
                        }
                    }
                    else break;
                }
            }

        }
    }
    private void CreateText(string text, string content)
    {
#pragma warning disable IDE0090 // Use 'new(...)'
        GameObject textObj = new GameObject(text, typeof(TextMeshProUGUI))
        {
            name = text
        };
#pragma warning restore IDE0090 // Use 'new(...)'
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = Vector3.zero;
        textObj.transform.localScale = Vector3.one;
        textObj.GetComponent<TextMeshProUGUI>().text = content;
        textObj.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        textObj.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.MidlineLeft;
    }
}
