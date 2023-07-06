using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScrypt: MonoBehaviour
{

    public bool resetable;
    public GameObject door;
    public bool startOpen;

    bool firstTrigger = false;
    bool open = true;
    Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();

        if (!startOpen)
        {
            open = false;
            doorAnim.SetTrigger("doorTrigger");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !firstTrigger)
        {
            if (!resetable) firstTrigger = true;
            doorAnim.SetTrigger("setTrigger");
            open = !open;
        }
    }
}
