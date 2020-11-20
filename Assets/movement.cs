using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
        animator.SetBool("isrunning", true);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run();
        }
    }

    public void Jump()
    {
        animator.SetTrigger("jump"); 
    }
    public void run()
    {
        animator.SetBool("isrunning", false); 
    }
}
