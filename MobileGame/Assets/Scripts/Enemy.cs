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
        model = transform.Find("Model").gameObject;
        UI = model.transform.Find("UI").gameObject;
        UpdateLifeDisplay();
          float size = .3f;
        for(int i = 0;i<life;i++) {
          float d = Mathf.Abs(i-life/2);
          GameObject pip = Instantiate(healthPip,
            transform.position+new Vector3(-.5f+size/2+i/life,.9f+UI.transform.position.y-d/life,0),
            Quaternion.identity
          );
          pip.transform.localScale *= (size+.2f-d*.4f);
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
      // transform.localScale *= 1.2f;
      if(life<=0) {
        clickHandler?.HandleDie();
        //die event
        // Destroy(gameObject);
      } else {
      clickHandler?.HandleClick();

      }
    }

    void OnMouseDown() {
      Damage();
    }
}
