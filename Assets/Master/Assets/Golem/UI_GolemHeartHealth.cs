using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GolemHeartHealth : MonoBehaviour
{
    public Image healthBar;

    float health, maxHealth = 1000;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;
        

        HealthBarFiller();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    
    private float _delay = 10;

    public void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay -= Time.fixedDeltaTime;

            if (_delay <= 0)
            {
                health = health - 100;
                _delay = 10;
            }
        }
    }

}