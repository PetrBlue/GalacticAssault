using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : EnemyBulletSpawn
{
    public BossShooting()
    {
        timeoutTime = 0.3f;
    }
    // Start is called before the first frame update
    void Start()
    {
        // TODO: LASER
    }

    // Update is called once per frame
    public override void Update()
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
}
