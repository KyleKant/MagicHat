using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_audioSource;
    private void Start()
    {
        m_audioSource = FindObjectOfType<ButtonSound>().GetComponent<AudioSource>();
    }
    private void OnMouseDown()
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
