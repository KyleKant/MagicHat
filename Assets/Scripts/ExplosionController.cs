using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        //gameManager.isGamePlaying = false;
        StartCoroutine(IEDestroy(1.333f));
    }
    private IEnumerator IEDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.currentGameState = GameState.GameOver;
        Destroy(this.gameObject);

    }
}
