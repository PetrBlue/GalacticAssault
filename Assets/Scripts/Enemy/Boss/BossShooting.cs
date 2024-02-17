using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : EnemyBulletSpawn
{
    [SerializeField]
    GameObject[] lasers;
    float curLaserTimeout;
    float laserTimeout = 5f;
    float laserChance = 2f; // out of 1k, so 0.2% chance

    [SerializeField]
    GameObject minion;
    float spawnY = 3f;
    float curMinionTimeout;
    float minionTimeout = 3.5f;
    public BossShooting()
    {
        timeoutTime = 0.3f;
    }
    void Start()
    {
        curLaserTimeout = laserTimeout;
        curMinionTimeout = minionTimeout;
    }

    public override void Update()
    {
        ShootBullet();
        ShootLaser();
        SpawnMinion();
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
        Destroy(Instantiate(bullet, position, Quaternion.identity), 3);
        curTimeout = timeoutTime;
        lastPosition = curPosition;
    }
    void ShootLaser()
    {
        if (curLaserTimeout > 0f)
        {
            curLaserTimeout -= Time.deltaTime;
            return;
        }
        if (Random.Range(1, 1001) <= laserChance)
        {
            if(Random.Range(0,2) == 0)
            {
                Instantiate(lasers[0]);
            }
            else
            {
                Instantiate(lasers[1]);
            }
            curLaserTimeout = laserTimeout;
        }
    }
    void SpawnMinion()
    {
        if (curMinionTimeout > 0f)
        {
            curMinionTimeout -= Time.deltaTime;
            return;
        }
        Destroy(Instantiate(minion, new Vector3(spawner.position.x, Random.Range(-spawnY, spawnY), spawner.position.z), Quaternion.identity), 10f);
        curMinionTimeout = minionTimeout;
    }
}
