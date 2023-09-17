using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private TextMeshProUGUI timeText;
    private TextMeshProUGUI scoreText;
    private PlayerDataList playerDataList;
    private PlayerDataManager playerDataManager;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerDataManager = FindObjectOfType<PlayerDataManager>();
    }
    private void Update()
    {
        playerDataList = playerDataManager.ReadFile("Player Score.json");
        if (playerDataList.PlayerDatas == null)
        {
            playerDataList.PlayerDatas = new();
        }
        Debug.Log(playerDataList.PlayerDatas.Count);
        //if (playerManager != null)
        //{
        //    if (this.gameObject.GetComponentsInChildren<TextMeshProUGUI>().Length < playerManager.playerData.playerDataDict.Count)
        //    {
        //        for (int i = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>().Length; i < playerManager.playerData.playerDataDict.Count; i++)
        //        {
        //            Debug.Log(playerManager.playerData.playerDataDict.Count);
        //            CreateText($"Score Text {i}", playerManager.playerData.playerDataDict[i].dateTime);
        //        }
        //    }
        //}
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
