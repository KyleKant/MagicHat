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
    private void OnEnable()
    {
        PlayerManager.OnDecreaseLifeNumberVariable += PlayerManager_OnChangeLifeNumberVariable;
        PlayerManager.OnIncreaseLifeNumberVariable += PlayerManager_OnIncreaseLifeNumberVariable;
    }

    private void PlayerManager_OnIncreaseLifeNumberVariable(int newLifeNumber)
    {
        if (this != null)
        {
            GameObject heartObject = Instantiate(heartObj);
            heartObject.transform.SetParent(this.transform, false);
        }
    }

    private void PlayerManager_OnChangeLifeNumberVariable(int newLifeNumber)
    {
        if (this != null)
        {
            Destroy(this.transform.GetComponentsInChildren<Image>().Last().gameObject);
        }
    }
}
