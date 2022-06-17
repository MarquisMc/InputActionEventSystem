using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void SetCurrentHealth(float newData)
    {
        currentHealth = newData;
    }

    public void DealDamage(FloatData damage)
    {
       currentHealth = currentHealth - damage.GetData();
    }
}
