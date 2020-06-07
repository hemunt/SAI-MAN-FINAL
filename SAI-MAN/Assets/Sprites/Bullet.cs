using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed;
    public float lifeTime;
    private Vector2 MouseTarget;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseTarget = new Vector2(difference.x,difference.y);
    }

    // Update is called once per frame
    void Update()
    {
        
 
        transform.position = Vector3.MoveTowards(transform.position, MouseTarget, Speed * Time.deltaTime);
        if (transform.position.x == MouseTarget.x && transform.position.y == MouseTarget.y) {
            DestroyProjectile();
        }
    }
    void DestroyProjectile() {
        Destroy(gameObject);
    }
}
