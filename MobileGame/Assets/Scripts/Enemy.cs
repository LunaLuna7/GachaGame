using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float life = 3;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeDisplay();
          float size = .3f;
        for(int i = 0;i<life;i++) {
          GameObject test = Instantiate(
            GameObject.CreatePrimitive(PrimitiveType.Cube),
            transform.position+new Vector3(-.5f+size/2+i/life,1,0),
            Quaternion.identity);
          test.GetComponent<BoxCollider>().enabled = false;
          test.transform.localScale *= size;
          test.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
      transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, .5f);
    }

    void UpdateLifeDisplay() {
      
    }

    void Damage() {
      //damage event
      life--;
      transform.localScale *= 2f;
      UpdateLifeDisplay();
      // transform.localScale *= 1.2f;
      if(life<=0) {
        //die event
        Destroy(gameObject);
      }
    }

    void OnMouseDown() {
      Damage();
    }
}
