using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_audioSource;
    private GameManager m_gameManager;
    private void Start()
    {
        m_audioSource = FindObjectOfType<ButtonSound>().GetComponent<AudioSource>();
        m_gameManager = FindObjectOfType<GameManager>();
    }
    private void OnMouseDown()
    {
        if (m_gameManager.currentGameState == GameState.Play)
        {
            if (m_audioSource != null)
            {
                m_audioSource.PlayOneShot(m_audioSource.clip);
                Destroy(this.gameObject, m_audioSource.clip.length * 0.5f);
            }
            else
            {
                Debug.Log("m_AudioSource is null");
            }
        }
    }
}
