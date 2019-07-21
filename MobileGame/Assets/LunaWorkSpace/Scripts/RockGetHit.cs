using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGetHit : MonoBehaviour
{
    public GameObject rocks;
    public void InstantiateRocks(int value)
    {
        for(int i = 0; i < value; i++)
        {
            float xVel = Random.Range(-1f,1f);
            float zVel = Random.Range(-1f,1f);

            Vector3 spawnPos = new Vector3(this.transform.position.x + xVel, this.transform.position.y, this.transform.position.z + zVel);
            GameObject instance = Instantiate(rocks, spawnPos, Quaternion.identity);

            Destroy(instance, 1f);

            Vector3 targetVel = new Vector3(100 * xVel, 0, 100 * zVel);
            instance.GetComponent<Rigidbody>().AddForce(targetVel);
        }
    }
}
