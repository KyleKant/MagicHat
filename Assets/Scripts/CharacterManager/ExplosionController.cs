using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public delegate void LifeLostDueExplosionBomb(int lifeLost);
    public static LifeLostDueExplosionBomb OnLifeLostDueExplosionBomb;
    private void Start()
    {
        StartCoroutine(IEDestroy(1.333f));
    }
    private IEnumerator IEDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnLifeLostDueExplosionBomb?.Invoke(1);
        Destroy(this.gameObject);

    }
}
