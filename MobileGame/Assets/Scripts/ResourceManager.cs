using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameEvent OnResourceUpdated;
    public List<Placeable> placeables;

    public void Start() {
      OnResourceUpdated.Raise();
    }
    public void UpdatePlaceablity() {
      foreach(Placeable p in placeables) {
        p.updateAvailable();
      }
    }
}
