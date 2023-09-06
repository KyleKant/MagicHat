using UnityEngine;

public class BombController : MonoBehaviour
{
    private GameManager gameManager;
    private TopPointController topPoint;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        topPoint = FindObjectOfType<TopPointController>();
    }
    private void Update()
    {
        if (gameManager != null)
        {
            if (this.transform.position.y > topPoint.transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnMouseDown()
    {
        gameManager.isGameOver = true;
    }
}
