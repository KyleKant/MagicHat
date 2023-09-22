using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LifeNumber : MonoBehaviour
{
    [SerializeField] private GameObject heartObj;
    private PlayerManager playerManager;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        if (heartObj != null)
        {
            if (playerManager.GetLifeNumber() > 0)
            {
                for (int i = 0; i < playerManager.GetLifeNumber(); i++)
                {
                    GameObject gameObject = Instantiate(heartObj);
                    gameObject.transform.SetParent(this.transform, false);
                }
            }
        }
    }
    private void Update()
    {
    }
    private void OnEnable()
    {
        PlayerManager.OnChangeLifeNumberVariable += PlayerManager_OnChangeLifeNumberVariable;
    }

    private void PlayerManager_OnChangeLifeNumberVariable(int newLifeNumber)
    {
        if (this != null)
        {
            Destroy(this.transform.GetComponentsInChildren<Image>().Last().gameObject);
            Debug.Log("Player did lost one life");
        }
    }
}
