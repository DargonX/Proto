using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    float currentHealth;

    public Slider playerHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float hp)
    {
        currentHealth += hp;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        playerHealthSlider.value = currentHealth;
    }

    public void makeDead()
    {
            Destroy(gameObject);
    }
}
