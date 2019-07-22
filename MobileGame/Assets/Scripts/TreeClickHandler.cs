using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeClickHandler : ClickHandlerBase
{
   private RockGetHit particles;


    [SerializeField]
    private GameEvent onDamaged;
    [SerializeField]
    private GameEvent onDie;
  void Start() {
    particles = GetComponent<RockGetHit>();
  }
  override public void HandleClick() {
    particles.InstantiateRocks(3);
    onDamaged.Raise();
  }
  override public void HandleDie() {
    particles.InstantiateRocks(7);
    onDie.Raise();
  }
}
