using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour, IHealable
{
    [SerializeField]
    private FloatReference health;

    [SerializeField]
    private GameEvent onPlayerDamaged;

    public void Heal(float value)
    {
        AddHealth(value);
    }

    private void AddHealth(float value)
    {
        health.Value += value;
        
        if(value < 0)
        {
            onPlayerDamaged.Raise();
        }
    }
}
