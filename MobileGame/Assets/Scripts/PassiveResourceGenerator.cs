using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveResourceGenerator : MonoBehaviour
{
    [SerializeField]
    private FloatReference resource;
    [SerializeField]

    private float time;
    [SerializeField]
    private float amount;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0) {
          timer = time;
          resource.Value += amount;
        }
    }
}
