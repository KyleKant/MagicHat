using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        Debug.Log("Coin had been pressed");
        GameObject scorePlusText = new GameObject();
    }
}
