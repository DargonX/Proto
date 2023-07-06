using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safeHouseDoorController : MonoBehaviour
{

    AudioSource safeDoorAudio;

    bool inSafe = false;

    //HUD
    public Text endGameText;
    public restartGame theGameController;
    // Use this for initalization
    void Start()
    {
        safeDoorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player" && inSafe == false)
        {
            Animator safeDoorAnim = GetComponentInChildren<Animator>();
            safeDoorAnim.SetTrigger("safeHouseTrigger");
            safeDoorAudio.Play();
            endGameText.text = "Safe House";
            Animator endGameAnim = endGameText.GetComponent<Animator>();
            endGameAnim.SetTrigger("endGame");
            theGameController.restartTheGame();
        }

    }

}

