using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private GameObject model;
  private Vector3 startPos;
  [SerializeField]
  private FloatReference health;
    // Start is called before the first frame update
    void Start()
    {
        model = transform.Find("Model").gameObject;
        startPos = model.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.position = startPos + Vector3.down*(1-health.Value/100)*1.4f;
    }
}
