using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClickHandler : ClickHandlerBase
{
  private RockGetHit rockGetHit;
  void Start() {
    rockGetHit = GetComponent<RockGetHit>();
  }
  override public void HandleClick() {
    rockGetHit.InstantiateRocks(10);
  }
}
