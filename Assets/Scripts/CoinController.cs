using UnityEngine;

public class CoinController : MonoBehaviour
{
    private const int MULTIPLES = 100;
    [SerializeField] private GameObject textObject;
    PlayerManager playerManager;
    private GameObject textObj;
    private TopPointController topPoint;
    private GameManager gameManager;
    private DataStorageController dataStorageController;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        topPoint = FindObjectOfType<TopPointController>();
        gameManager = FindObjectOfType<GameManager>();
        dataStorageController = FindObjectOfType<DataStorageController>();
    }
    private void Update()
    {
        if (this.gameObject != null)
        {
            if (this.transform.position.y > topPoint.transform.position.y)
            {
                gameManager.isGameOver = true;
                gameManager.isGamePlaying = false;
            }
        }
    }
    private void OnMouseDown()
    {
        textObj = Instantiate(textObject);
        textObj.transform.GetChild(textObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
        playerManager.scoreOfPlayer += 1;
        if (playerManager.scoreOfPlayer > playerManager.highScoreOfPlayer)
        {
            playerManager.highScoreOfPlayer = playerManager.scoreOfPlayer;
        }
        Debug.Log($"playerManager.scoreOfPlayer: {playerManager.scoreOfPlayer}, playerManager.HighScoreOfPlayer: {playerManager.highScoreOfPlayer}");
        Destroy(this.gameObject);

    }

}
