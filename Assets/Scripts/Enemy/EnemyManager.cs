using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    public int health { get; set; }
    public int bulletHit { get; set; } = 10;
    public void BulletHit()
    {
        health -= bulletHit;
        if (health <= 0)
        {
            Debug.Log("Enemy is dead!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Enemy HP: " + health);
        }
    }
}
