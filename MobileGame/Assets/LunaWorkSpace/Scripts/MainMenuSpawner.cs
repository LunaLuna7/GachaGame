using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSpawner : MonoBehaviour
{
    [SerializeField]
    private float maxTime;
    
    [SerializeField]
    private float minTime;

    [SerializeField]
    private Transform maxX;
    
    [SerializeField]
    private Transform minX;

    [SerializeField]
    private Transform maxZ;
    
    [SerializeField]
    private Transform minZ;

    [SerializeField]
    private GameObject enemyPrefab;

    private void Start() 
    {
        StartCoroutine(Spawner());    
    }

    private void SpawnRock()
    {
        Vector3 targetPos = new Vector3(Random.Range(minX.position.x, maxX.position.x), 0, Random.Range(minZ.position.z, maxZ.position.z));
        Instantiate(enemyPrefab, targetPos, Quaternion.identity);
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            SpawnRock();
        }
    }
}
