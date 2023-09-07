using UnityEngine;

public class CoinController : MonoBehaviour
{
    private const int MULTIPLES = 100;
    [SerializeField] private GameObject textObject;
    private ChangeScoreController changeScoreController;
    private GameObject textObj;
    private TopPointController topPoint;
    private GameManager gameManager;
    private void Start()
    {
        changeScoreController = FindObjectsOfType<ChangeScoreController>()[0];
        topPoint = FindObjectOfType<TopPointController>();
        gameManager = FindObjectOfType<GameManager>();
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
        changeScoreController.scoreOfPlayer += 1;
        Destroy(this.gameObject);

    }

}
