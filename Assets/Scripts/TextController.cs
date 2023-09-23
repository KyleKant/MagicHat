using System.Collections;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] private float speed = 0.8f;
    [SerializeField] private TextBubbleSO textBubble;
    private Transform text;
    private void Start()
    {
        this.GetComponent<Canvas>().worldCamera = Camera.main;
        int childCount = this.transform.childCount;
        text = this.gameObject.transform.GetChild(childCount - 1);
        text.GetComponent<TextMeshProUGUI>().enableWordWrapping = false;
        text.GetComponent<TextMeshProUGUI>().text = textBubble.contentText;
        text.GetComponent<TextMeshProUGUI>().fontSize = 50;
        StartCoroutine(IEDestroyText(.5f));
    }
    private IEnumerator IEDestroyText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
    private void Update()
    {
        text.GetComponent<RectTransform>().Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
