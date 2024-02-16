using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    [SerializeField]
    protected Transform spawner;
    [SerializeField]
    protected GameObject bullet;
    protected float curTimeout = 0f;
    protected float timeoutTime = 0.5f;
    protected Vector2 lastPosition;
    protected Vector2 curPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    public virtual void Update()
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
