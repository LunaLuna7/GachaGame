using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public GameObject enemy;
  public float time;
  private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer<0) {
          timer = time;
          float width = 6f;
          float height = 4f;
          float angle = Random.Range(0,360);
          float x = Mathf.Cos(angle)*width;
          float z = Mathf.Sin(angle)*height;
          Vector3 pos = new Vector3(
            x,
            0,
            z
          );
          GameObject en = Instantiate(enemy, pos, Quaternion.identity);
          en.GetComponent<Enemy>().life = Random.Range(1,4);
        }
    }
}
