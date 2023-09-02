using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;

    private void Update()
    {
        if( this.transform.position.y  > -7f && this.transform.position.y < 5f)
        {
            this.transform.Translate(new Vector3(0, speed, 0));
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log($"gameObject: {this.gameObject} was destroyed");
        }
    }
}
