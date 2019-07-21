using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClickHandler : ClickHandlerBase
{
  private RockGetHit rockGetHit;


    [SerializeField]
    private GameEvent onEnemyDamaged;
    [SerializeField]
    private GameEvent onEnemyDie;
  void Start() {
    rockGetHit = GetComponent<RockGetHit>();
  }
  override public void HandleClick() {
    rockGetHit.InstantiateRocks(5);
    onEnemyDamaged.Raise();
  }
  override public void HandleDie() {
    rockGetHit.InstantiateRocks(10);
    onEnemyDie.Raise();
  }
}
