using TMPro;
using UnityEngine;

public class ChangeScoreController : MonoBehaviour
{
    public int scoreOfPlayer;
    private void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = $"Score: {scoreOfPlayer}";
    }
}
