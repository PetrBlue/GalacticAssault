using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBulletSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform spawner;
    float curTimeout;
    float timeoutTime = 2.5f;
    float rotateSpeed = 180f;
    // Start is called before the first frame update
    void Start()
    {
        curTimeout = timeoutTime;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the ball bullet, by z, by speed * time.deltaTime
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        if (curTimeout > 0f)
        {
            curTimeout -= Time.deltaTime;
            return;
        }
        Destroy(Instantiate(bullet, spawner.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w)), 7f);
        Destroy(Instantiate(bullet, spawner.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+90, transform.rotation.w)), 7f);
        Destroy(Instantiate(bullet, spawner.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+180, transform.rotation.w)), 7f);
        Destroy(Instantiate(bullet, spawner.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+270, transform.rotation.w)), 7f);
        curTimeout = timeoutTime;
    }
}
