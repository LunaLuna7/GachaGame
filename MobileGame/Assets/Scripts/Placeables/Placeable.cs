using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource : System.Object
{
    public FloatReference resource;
    public float amount;
}

[CreateAssetMenu]

public class Placeable : ScriptableObject
{
    public List<Resource> cost;
    public GameEvent OnPlaceable;
    public GameEvent OnNotPlaceable;
    public GameEvent OnResourceChanged;
    public bool available;
    public void Purchase() {
      foreach(Resource r in cost) {
        r.resource.Value -= r.amount;
        OnResourceChanged.Raise();
      }
    }
    public bool Available() {
      foreach(Resource r in cost) {
        if(r.resource.Value < r.amount) {
          return false;
        }
      }
      return true;
    }
    public void updateAvailable() {
      bool av = Available();
      // if(av!=available) {
      //   if(av) {
      //     OnPlaceable.Raise();
      //   } else {
      //     OnNotPlaceable.Raise();
      //   }
      // }
      available = av;
    }
}
