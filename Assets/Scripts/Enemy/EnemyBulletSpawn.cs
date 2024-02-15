using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField]
    Transform spawner;
    [SerializeField]
    GameObject bullet;
    float curTimeout = 0f;
    float timeoutTime = 0.5f;
    Vector2 lastPosition;
    Vector2 curPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        curPosition = (Vector2)transform.position;
        if (curTimeout > 0f)
        {
            curTimeout -= Time.deltaTime;
            lastPosition = curPosition;
            return;
        }
        if (curPosition == lastPosition)
        {
            Vector3 position = spawner.position;
            Destroy(Instantiate(bullet, position, Quaternion.identity), 3);
            curTimeout = timeoutTime;
        }
        lastPosition = curPosition;
    }
}
