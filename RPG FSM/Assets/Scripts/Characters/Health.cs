using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    public event Action OnDie;

    public bool IsDead => health == 0;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        if (health == 0) return;
        health = (int)MathF.Max(health - damage, 0);

        if(health == 0)
            OnDie?.Invoke();

        Debug.Log(health);
    }
}
