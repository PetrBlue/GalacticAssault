using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 100;
    public int bulletHit = 10;
    public int enemyHit = 50;
    public int laserHit = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletHit()
    {
        health -= bulletHit;
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
        }
        else
        {
            Debug.Log("Player HP: " + health);
        }
    }
    public void EnemyCollision()
    {
        health -= enemyHit;
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
        }
        else
        {
            Debug.Log("Player HP: " + health);
        }
    }
    public void LaserHit()
    {
        health -= bulletHit;
        if (health <= 0)
        {
            Debug.Log("Player is dead!");
        }
        else
        {
            Debug.Log("Player HP: " + health);
        }
    }
}
