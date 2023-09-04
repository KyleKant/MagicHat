using UnityEngine;

public class CoinController : MonoBehaviour
{
    private const string BACKGROUND = "background";
    private const int SCREEN_WIDTH = 720;
    private const int SCREEN_HEIGHT = 1280;
    private const int MULTIPLES = 100;
    private const int FONT_SIZE = 50;
    private const int TEXT_RECT_WIDTH = 200;
    private const int TEXT_RECT_HEIGHT = 50;
    private Camera _camera;
    private GameObject textObj;
    [SerializeField] private GameObject textObject;
    private void Start()
    {
        _camera = Camera.main;
    }
    private void OnMouseDown()
    {
        textObj = Instantiate(textObject);
        textObj.transform.GetChild(textObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
        Destroy(this.gameObject);

    }
}
