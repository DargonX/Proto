using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    //movement variables
    [Header("Movement Settings")]
    [SerializeField] float runSpeed;
    [SerializeField] float walkSpeed;
    bool running;

    Rigidbody myRB;
    Animator myAnim;

    bool facingRight;

    //for jumping
    [Header("Jump Settings")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpHeight;
    [SerializeField] float groundCheckRadius = 0.05f;
    bool grounded = false;
    Collider[] groundCollisions;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;

    }

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {

        running = false;

        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("grounded", grounded);
            myRB.velocity = new Vector3 (myRB.velocity.x, 0, 0); 
            myRB.AddForce(new Vector3(0, jumpHeight, 0));
        }
        
        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0 )
        {
            grounded = true;
        }
        else grounded = false;

        myAnim.SetBool("grounded", grounded);

        //jumping
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        float sneaking = Input.GetAxisRaw("Fire3");

        float firing = Input.GetAxisRaw("Fire1");

        if((sneaking > 0 || firing > 0) && grounded)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
        }
        else
        {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
            if(Mathf.Abs(move) > 0) running = true;
        }

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public float GetFacing()
    {
        if (facingRight) return 1;
        else return -1;
    }

    public bool getRunning()
    {
        return (running);
    }

}