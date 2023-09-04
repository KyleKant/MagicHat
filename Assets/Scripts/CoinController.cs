using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
        //DisplayTextObj();
        textObj = Instantiate(textObject);
        textObj.transform.GetChild(textObj.transform.childCount - 1).GetComponent<RectTransform>().localPosition = this.transform.position * MULTIPLES;
        Destroy(this.gameObject);

    }
    private void DisplayTextObj()
    {
        if (_camera != null)
        {
            Dictionary<string, GameObject> textObjDict = CreateTextObject("scorePlus");
            Canvas scorePlusCanvas = textObjDict["canvas"].GetComponent<Canvas>();
            TextMeshPro scorePlusText = textObjDict["textMeshPro"].GetComponent<TextMeshPro>();
            CanvasSettings(scorePlusCanvas, RenderMode.ScreenSpaceCamera, _camera, BACKGROUND, CanvasScaler.ScaleMode.ScaleWithScreenSize, new Vector2(SCREEN_WIDTH, SCREEN_HEIGHT));
            CreateText(scorePlusText, "+1", FONT_SIZE, TextAlignmentOptions.Center, Color.yellow, FontStyles.Bold);
            TextRect(scorePlusText, this.transform.position * MULTIPLES, new Vector2(TEXT_RECT_WIDTH, TEXT_RECT_HEIGHT));
            StartCoroutine(IEDestroyScorePlusText(0.2f, scorePlusCanvas, scorePlusText));
        }
    }
    private IEnumerator IEDestroyScorePlusText(float seconds, Canvas canvas, TextMeshPro text)
    {
        Debug.Log("waiting for 1 second");
        yield return new WaitForSeconds(seconds);
        Destroy(canvas.gameObject);
        Destroy(text.gameObject);
        Debug.Log("waited for 1 second");
        Destroy(this.gameObject);
        Debug.Log($"{this.gameObject} had been destroyed");
    }
    private Dictionary<string, GameObject> CreateTextObject(string name)
    {
        GameObject textCanvas = new GameObject(name + "Canvas", typeof(Canvas));
        GameObject textObject = new GameObject(name + "Text", typeof(TextMeshPro));
        textObject.transform.SetParent(textCanvas.transform, false);
        Dictionary<string, GameObject> gameObjDict = new Dictionary<string, GameObject>();
        gameObjDict.Add("canvas", textCanvas);
        gameObjDict.Add("textMeshPro", textObject);
        return gameObjDict;
    }
    private void CanvasSettings(Canvas canvas, RenderMode renderMode, Camera camera, string sortingLayerName, CanvasScaler.ScaleMode scaleMode, Vector2 screenSize)
    {
        canvas.GetComponent<Canvas>().renderMode = renderMode;
        if (renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvas.GetComponent<Canvas>().worldCamera = camera;
        }
        canvas.GetComponent<Canvas>().sortingLayerName = sortingLayerName;
        CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = scaleMode;
        scaler.referenceResolution = screenSize;
    }
    private void CreateText(TextMeshPro text, string textContent, int fontSize, TextAlignmentOptions textAlignmentOptions, Color textColor, TMPro.FontStyles fontStyle)
    {
        text.text = textContent;
        text.fontSize = fontSize;
        text.alignment = textAlignmentOptions;
        text.color = textColor;
        text.fontStyle = fontStyle;
        text.isOrthographic = true;
        text.sortingOrder = 1;
    }
    private void TextRect(TextMeshPro text, Vector3 position, Vector2 textRectSize)
    {
        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.localPosition = position;
        textRect.sizeDelta = textRectSize;
    }
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }
}
