using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  private GameObject player;
  private Rigidbody rb;
  public float speed = 1;
  public bool attacking = false;
  public float attackSpeed = 1;
  private float attackTimer = 0.2f;
  public float damage = 5;
  private GameObject model;

  public GameEvent onPlayerDamaged;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        model = transform.Find("Model").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = player.transform.position - transform.position;
        diff.y = 0;
        
        transform.rotation = Quaternion.LookRotation(diff);
        rb.velocity = transform.forward * speed;
        model.transform.rotation=transform.rotation;
        model.transform.Rotate(0,0,Mathf.Cos(Time.fixedTime*6)*10);

        if(attacking) {
          model.transform.Rotate(-30+attackTimer*60,0,0);
          model.transform.localPosition = new Vector3(
            0,0,-.5f+attackTimer*1
          );
          attackTimer -= Time.deltaTime;
          if(attackTimer<=0) {
            attackTimer = attackSpeed;
            Attack();
          }
        }
    }

    void Attack() {
      player.GetComponent<HealthManager>().Heal(-damage);
      model.transform.localScale *= 1.2f;
    }

    void OnCollisionEnter(Collision col) {
      if(col.gameObject.tag=="Player") {
        //frikin die
        attacking = true;
      }
    }

     void OnCollisionExit(Collision col) {
      if(col.gameObject.tag=="Player") {
        //frikin die
        attacking = false;
      }
    }
}
