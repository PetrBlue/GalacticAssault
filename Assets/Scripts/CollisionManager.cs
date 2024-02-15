using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public PlayerManager manager;
    private void Start()
    {
        manager = GetComponent<PlayerManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player collided with a bullet!");
            Destroy(collision.gameObject);
            manager.BulletHit();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with an enemy!");
            manager.EnemyCollision();
        }
    }
}
