using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spicks : MonoBehaviour
{


    private BoxCollider2D collider;
    public float Up;
    // Start is called before the first frame update
    void Start()
    {
       
        collider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      

            Vector3 spikes = transform.position;
            spikes.y += Up;
            transform.position = spikes;
            collider.enabled = false;
      
    }
}
