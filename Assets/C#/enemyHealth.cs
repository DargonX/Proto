using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damagePartticles;
    public bool drops;
    public GameObject drop;

    float currentHealth;

    public Slider enemyHealthIndicator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 0f) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        if (currentHealth <= 0) makeDead();
    }

    void makeDead()
    {
        zombieController aZombie = GetComponentInChildren<zombieController>();
        if(aZombie != null)
        {
            aZombie.ragdollDeath();
        }

        Destroy(gameObject.transform.root.gameObject);
        if (drops) Instantiate(drop, transform.position, transform.rotation);
    }
}
