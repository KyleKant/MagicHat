using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private PlayerDataList playerDataList = new();
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
            if ((this.gameObject.GetComponentsInChildren<TextMeshProUGUI>().Length / 2) < playerDataList.PlayerDatas.Count)
            {
                for (int i = playerDataList.PlayerDatas.Count - 1; i >= 0; i--)
                {
                    if (playerDataList.PlayerDatas[i].highScore != 0)
                    {
                        CreateText($"Score Text {i}", playerDataList.PlayerDatas[i].highScore.ToString());
                        CreateText($"Time Text {i}", playerDataList.PlayerDatas[i].dateTime);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
    private void CreateText(string text, string content)
    {
        GameObject textObj = new GameObject(text, typeof(TextMeshProUGUI));
        textObj.name = text;
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = Vector3.zero;
        textObj.transform.localScale = Vector3.one;
        textObj.GetComponent<TextMeshProUGUI>().text = content;
        textObj.GetComponent<TextMeshProUGUI>().color = Color.yellow;
        textObj.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.MidlineLeft;
    }
}
