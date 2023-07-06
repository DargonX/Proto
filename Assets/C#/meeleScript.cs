using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meeleScript : MonoBehaviour
{

    public float damage;
    public float knockBack;
    public float meeleRate;
    public float knockBackRadius;

    float nextMeele;

    int shootableMask;

    Animator myAnim;
    playerController myPC;

    // Start is called before the first frame update
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        myAnim = transform.root.GetComponent<Animator>();
        myPC = transform.root.GetComponent<playerController>();
        nextMeele = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float meele = Input.GetAxis("Fire2");
        if(meele > 0 && nextMeele < Time.time && !(myPC.getRunning()))
        {
            myAnim.SetTrigger("gunMeele");
            nextMeele = Time.time + meeleRate;

            //do damage
            Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);
                       
            int i = 0;
            while (i < attacked.Length)
            {
                if (attacked[i].tag == "Enemy")
                {
                    enemyHealth doDamage = attacked[i].GetComponent<enemyHealth>();
                    doDamage.addDamage(damage);
                }
                i++;
            }

        }

    }

}
