using UnityEngine;

public class OwlBlueController : MonoBehaviour
{
    private TopPointController topPoint;
    private void Start()
    {
        topPoint = FindObjectOfType<TopPointController>();
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
}
