using UnityEngine;

public class OwlBlueController : MonoBehaviour
{
    public delegate void PressedOwl(int buffOrDebufIndex);
    public static PressedOwl OnPressedOwl;
    [SerializeField] private GameObject[] bufforDebuffs;
    private GameManager gameManager;
    private const int MULTIPLES = 100;
    private TopPointController topPoint;
    private bool isClickedOwl;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        topPoint = FindObjectOfType<TopPointController>();
        isClickedOwl = false;
    }
    private void Update()
    {
        if (this.gameObject != null)
        {
            if (this.transform.position.y > topPoint.transform.position.y)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnMouseDown()
    {
        if (gameManager.currentGameState == GameState.Play)
        {
            if (this.gameObject != null)
            {
                if (!isClickedOwl)
                {
                    int indexRandom = Random.Range(0, bufforDebuffs.Length);
                    GameObject textBubleObj = Instantiate(bufforDebuffs[indexRandom]);
                    textBubleObj.transform.GetChild(textBubleObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
                    OnPressedOwl?.Invoke(indexRandom);
                    isClickedOwl = true;
                }

            }
        }
    }
}
