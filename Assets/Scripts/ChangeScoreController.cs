using TMPro;
using UnityEngine;

public class ChangeScoreController : MonoBehaviour
{
    private PlayerManager playerManager;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = $"Score: {playerManager.playerData.playerScore}";
    }
}
