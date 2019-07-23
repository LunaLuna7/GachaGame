using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceLabel : MonoBehaviour
{
  private Text text;
  [SerializeField]
  private FloatVariable resource;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLabel() {
      text.text = resource.RuntimeValue.ToString();
    }
}
