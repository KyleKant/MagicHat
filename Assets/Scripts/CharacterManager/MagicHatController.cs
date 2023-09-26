using System.Collections.Generic;
using UnityEngine;

public class MagicHatController : MonoBehaviour
{
    [SerializeField] private float respawnTime = 0.5f;
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private GameObject respawnPoint;
    private float increaseTime = 0f;
    private Dictionary<int, GameObject> keyValuePairs = new Dictionary<int, GameObject>();
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        for (int index = 0; index < gameObjects.Count; index++)
        {
            keyValuePairs.Add(index, gameObjects[index]);
        }
    }
    private void Update()
    {
        if (gameManager.isGamePlaying)
        {
            if (Time.time > increaseTime)
            {
                int randomKey = GetRandomNum(0, gameObjects.Count);
                GameObject respawnObject = GetRandomRespawnObject(keyValuePairs, randomKey);
                Respawn(respawnObject, respawnPoint);
                increaseTime = Time.time + respawnTime;
            }
        }
    }
    private int GetRandomNum(int minNum, int maxNum)
    {
        int randomNum = Random.Range(minNum, maxNum);
        return randomNum;
    }
    private GameObject GetRandomRespawnObject(Dictionary<int, GameObject> respawnObjectDict, int randomKey)
    {
        GameObject randomRespawnObject = respawnObjectDict[randomKey];
        return randomRespawnObject;
    }
    private void Respawn(GameObject respawnObject, GameObject respawnPoint)
    {
        Vector3 position = respawnPoint.transform.position;
        Quaternion rotation = respawnPoint.transform.rotation;
        Instantiate(respawnObject, position, rotation);
    }
}