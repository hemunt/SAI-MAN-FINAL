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
    public GameObject ShootUp;
    public GameObject ShootDown;
    public GameObject Bullet;
    public Transform GunPointLeft;
    public Transform GunPointRight;
    public int maxHealth = 100;
    //public GameObject AimIcone;
  

    private float timeBtwShots;
    public float StartTimeBtwShots;
   
   
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

        if (Input.GetMouseButton(1))
        {
            Vector2 UpPossition = ShootUp.transform.position;
            Vector2 DownPossition = ShootDown.transform.position;
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            anim.SetBool("Aiming", true);
            
            
            if (difference.y > UpPossition.y)
            {
                anim.SetBool("isAimingDown", false);
                anim.SetBool("isAimingMid", false);
                anim.SetBool("isAimingUp", true);
            }

            if (difference.y < UpPossition.y && difference.y > DownPossition.y)
            {
                anim.SetBool("isAimingDown", false);
                anim.SetBool("isAimingMid", true);
                anim.SetBool("isAimingUp", false);
            }

            if (difference.y < DownPossition.y)
            {
                anim.SetBool("isAimingDown", true);
                anim.SetBool("isAimingMid", false);
                anim.SetBool("isAimingUp", false);
            }
            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                   
            
                    Instantiate(Bullet, GunPointLeft.position, GunPointLeft.rotation);
                    Instantiate(Bullet, GunPointRight.position, GunPointRight.rotation);

                    timeBtwShots = StartTimeBtwShots;
                }
                else
                {
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            
            anim.SetBool("Aiming", false);
        }


    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;
    }
}
