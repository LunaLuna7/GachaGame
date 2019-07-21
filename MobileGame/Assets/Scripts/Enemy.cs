using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float life = 3;
  private GameObject UI;
  private GameObject model;
  public GameObject healthPip;
  private ClickHandlerBase clickHandler;
    // Start is called before the first frame update
    void Start()
    {
        clickHandler = GetComponent<ClickHandlerBase>();
        UI = transform.Find("UI").gameObject;
        model = transform.Find("Model").gameObject;
        UpdateLifeDisplay();
          float size = .3f;
        for(int i = 0;i<life;i++) {
          GameObject pip = Instantiate(healthPip,
            transform.position+new Vector3(-.5f+size/2+i/life,1+UI.transform.position.y,0),
            Quaternion.identity
          );
          pip.transform.localScale *= size;
          pip.transform.parent = UI.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
      model.transform.localScale = Vector3.Lerp(model.transform.localScale, Vector3.one, .5f);
      if(life<=0&&model.transform.localScale.x<1.1f) {
        Destroy(gameObject);
      }
    }

    void UpdateLifeDisplay() {
    }

    void Damage() {
      //damage event
      life--;
      model.transform.localScale *= 2f;
      if(life>=0)
       Destroy(UI.transform.GetChild(Mathf.FloorToInt(life)).gameObject);
      UpdateLifeDisplay();
      clickHandler?.HandleClick();
      // transform.localScale *= 1.2f;
      if(life<=0) {
        //die event
        // Destroy(gameObject);
      }
    }

    void OnMouseDown() {
      Damage();
    }
}
