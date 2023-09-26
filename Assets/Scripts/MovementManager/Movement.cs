using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }
}
