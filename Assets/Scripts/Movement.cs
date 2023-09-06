using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;

    private void Update()
    {
        this.transform.Translate(new Vector3(0, speed, 0));
    }
}
