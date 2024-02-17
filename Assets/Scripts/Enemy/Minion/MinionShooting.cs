using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionShooting : EnemyBulletSpawn
{
    public MinionShooting()
    {
        timeoutTime = 1f;
    }
    public override void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        curPosition = (Vector2)transform.position;
        if (curTimeout > 0f)
        {
            curTimeout -= Time.deltaTime;
            lastPosition = curPosition;
            return;
        }
        Vector3 position = spawner.position;
        Destroy(Instantiate(bullet, position, Quaternion.identity), 6);
        curTimeout = timeoutTime;
        lastPosition = curPosition;
    }
}
