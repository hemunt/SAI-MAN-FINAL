using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayeController : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public static GamePlayeController instance;
    public healthBar heathbar;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
           
        }
        heathbar.SetMaxHealth(maxPlayerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage) {
        maxPlayerHealth -= damage;
        heathbar.SetHealth(maxPlayerHealth);
    }
}
