using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class HealthEvent : MonoBehaviour
{
    public void DoHealthEvent(Health health, UltEventHolder ultEvent, float healthEventFloat)
    {
        if (health.currentHealth <= healthEventFloat)
        {
            ultEvent.Invoke();
        }
    }
}
