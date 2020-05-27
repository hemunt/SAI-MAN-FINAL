using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        transform.position = Vector3.MoveTowards(transform.position, difference, Speed * Time.deltaTime);
    }
    void DestroyProjectile() {
        Destroy(gameObject);
    }
}
