using UnityEngine;

public class CoinController : MonoBehaviour
{
    public delegate void IncreaseScore(int score);
    public static event IncreaseScore OnIncreaseScore;
    public delegate void LifeLost(int lifeLost);
    public static event LifeLost OnLifeLost;
    private const int MULTIPLES = 100;
    [SerializeField] private GameObject textObject;
    private GameManager gameManager;
    private GameObject textObj;
    private TopPointController topPoint;
    private bool isClickedCoin;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        topPoint = FindObjectOfType<TopPointController>();
        isClickedCoin = false;
    }
    private void Update()
    {
        if (this.gameObject != null)
        {
            if (this.transform.position.y > topPoint.transform.position.y)
            {
                OnLifeLost?.Invoke(1);
                Destroy(gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            if (isClickedCoin == false)
            {
                textObj = Instantiate(textObject);
                textObj.transform.GetChild(textObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
                OnIncreaseScore?.Invoke(1);
                isClickedCoin = true;
                //Destroy(this.gameObject);
            }
        }
    }

}
