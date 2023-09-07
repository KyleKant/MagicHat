using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
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
        GameObject explosionObj = Instantiate(explosion);
        explosionObj.transform.position = this.transform.position;
        gameManager.isGamePlaying = false;
        this.gameObject.SetActive(false);
        //gameManager.isGameOver = true;
    }
}
