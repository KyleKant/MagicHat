using System.Collections;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ExitGame()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        StartCoroutine(DelayToExitGame(_audioSource.clip.length * 0.25f));
    }
    private IEnumerator DelayToExitGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameManager.ExitGame();
    }
}
