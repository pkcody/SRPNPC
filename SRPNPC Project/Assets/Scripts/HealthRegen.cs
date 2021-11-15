using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthRegen : MonoBehaviour, IHealth
{
    // if health < blah then wait blah and regen
    [SerializeField]
    private int startingHealth = 100;

    private int currentHealth;

    [SerializeField]
    private float regenAfterAmountOfTime = 7f;
    [SerializeField]
    private float regenTime = 10f;

    private bool canRegen = false;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }
    private void Update()
    {
        if (!canRegen)
            if (currentHealth > 0)
                if (currentHealth < 100)
                {
                    Debug.Log("regen");
                    StartCoroutine(RegenTimer());
                }
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0)
        {
            currentHealth -= amount;

            OnHPPctChanged(CurrentHpPct);

            if (CurrentHpPct <= 0)
                OnDied();
        }
    }

    public void AddHealth()
    {
        if (canRegen && currentHealth < startingHealth)
        {
            currentHealth += 10;
            Debug.Log(currentHealth);
            StartCoroutine(RegenIntervals());
            OnHPPctChanged(CurrentHpPct);
            
            if(currentHealth >= startingHealth)
                canRegen = false;
        }
    }

    private IEnumerator RegenTimer()
    {
        canRegen = true;
        yield return new WaitForSeconds(regenAfterAmountOfTime);
        AddHealth();
    }

    private IEnumerator RegenIntervals()
    {
        yield return new WaitForSeconds(regenTime);
        AddHealth();
    }
}
