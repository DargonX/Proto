using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    float currentHealth;

    public GameObject playerDeathEffects;
    public Slider playerHealthSlider;

    public Image damageScreen;
    Color flashColor = new Color(255f, 255f, 255f, 1f);
    Color blankColor = new Color(0, 0, 0, 0);
    float flashSpeed = 5f;
    bool damaged = false;
    public Text endGameText;
    public restartGame theGameController;

    AudioSource playerAS;


    // Use this for initalization
    void Awake ()
    {
        currentHealth = fullHealth;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currentHealth;

        playerAS = GetComponent < AudioSource > ();

    }

    // Update is called once per frame


    public void addDamage(float damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        damaged = true;

        playerAS.Play();

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
        Instantiate(playerDeathEffects, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damageScreen.color = flashColor;
        Destroy(gameObject);
        Animator endGameAnim = endGameText.GetComponent<Animator>();
        endGameAnim.SetTrigger("endGame");
        theGameController.restartTheGame();
    }
}
