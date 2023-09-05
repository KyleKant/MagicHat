using UnityEngine;

public class CoinController : MonoBehaviour
{
    private const int MULTIPLES = 100;
    [SerializeField] private GameObject textObject;
    private ChangeScoreController changeScoreController;
    private GameObject textObj;
    private void Start()
    {
        changeScoreController = FindObjectsOfType<ChangeScoreController>()[0];
    }
    private void OnMouseDown()
    {
        textObj = Instantiate(textObject);
        textObj.transform.GetChild(textObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
        changeScoreController.scoreOfPlayer += 1;
        Destroy(this.gameObject);

    }

}
