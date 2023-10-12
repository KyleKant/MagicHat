using UnityEngine;

public class OKButton : MonoBehaviour
{
    //[SerializeField] private GameObject gameObj;
    [SerializeField] private GameDataManager gameDataManager;
    [SerializeField] private LevelManager levelManager;
    //private AudioSource audioSource;

    //private void Start()
    //{
    //    audioSource = FindObjectOfType<ButtonSound>().GetComponent<AudioSource>();
    //}
    //public void DeActiveObj()
    //{
    //    if (gameObj != null)
    //    {
    //        //audioSource.PlayOneShot(audioSource.clip);
    //        StartCoroutine(DelayToDeActiveObj(audioSource.clip.length * 0.25f));
    //    }
    //}
    //private IEnumerator DelayToDeActiveObj(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    gameObj.SetActive(false);
    //}
    public void ConfirmWriteData()
    {
        gameDataManager.WriteFile("GameData.json", levelManager.GetGameData());
    }
}
