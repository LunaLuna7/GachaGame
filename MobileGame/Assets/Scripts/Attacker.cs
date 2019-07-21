using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  public EnemyStats enemyStats;
  private GameObject player;
  private Rigidbody rb;
  public bool attacking = false;
  private float attackTimer = 0.2f;
  private GameObject model;
  private float moveTimer=0;

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
        rb.velocity = transform.forward * enemyStats.speed;
        model.transform.rotation=transform.rotation;
        moveTimer += Time.deltaTime;
        model.transform.Rotate(0,0,Mathf.Cos(moveTimer*10)*7);

        if(attacking) {
          model.transform.Rotate(-30+attackTimer*60,0,0);
          model.transform.localPosition = new Vector3(
            0,0,-.5f+attackTimer*1
          );
          attackTimer -= Time.deltaTime;
          if(attackTimer<=0) {
            attackTimer = enemyStats.attackSpeed;
            Attack();
          }
        }
    }

    void Attack() {
      player.GetComponent<HealthManager>().Heal(-enemyStats.damage);
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
