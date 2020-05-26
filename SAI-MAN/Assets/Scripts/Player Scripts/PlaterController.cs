using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaterController : MonoBehaviour
{
    public CharacterController2D controller;

    public float movespeed = 30f;
    float horizontalMove = 0f;
    bool jump = false;
    public Animator anim;
    private Transform tr;


    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movespeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            anim.SetTrigger("Jump");
        }
        if (horizontalMove == 0)
        {
            anim.SetBool("Running", false);

        }
        else if (horizontalMove > 0)
        {
            
           anim.SetBool("Running", true);
         
        }
        else if (horizontalMove < 0)
        {
          
            anim.SetBool("Running", true);
        }
        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;
    }
}
