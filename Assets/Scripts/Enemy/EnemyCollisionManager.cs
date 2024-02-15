using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCollisionController : MonoBehaviour
{
    public EnemyManager manager;
    private void Start()
    {
        manager = GetComponent<EnemyManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy collided with a bullet!");
            Destroy(collision.gameObject);
            manager.BulletHit();
        }
    }
}
