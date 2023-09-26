using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_audioSource;
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        m_audioSource.PlayOneShot(m_audioSource.clip);
        Destroy(this.gameObject, m_audioSource.clip.length * 0.5f);
    }
}
