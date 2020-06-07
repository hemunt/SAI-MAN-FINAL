using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{



    private float timeBtwShots;
    public float StartTimeBtwShots;
    public GameObject Bullet;



    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = StartTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            timeBtwShots = StartTimeBtwShots; 
            timeBtwShots = StartTimeBtwShots;       
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
