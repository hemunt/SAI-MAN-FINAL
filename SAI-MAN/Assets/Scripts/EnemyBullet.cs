using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    public float speed;
    private Transform Player;
    private Vector2 Target;
    private GamePlayeController instance;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Target = new Vector2(Player.position.x, Player.position.y);
        instance = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayeController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision == GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>())
        {
            instance.TakeDamage(50);
        }
    }
}
