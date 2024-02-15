using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField]
    Transform spawner;
    [SerializeField]
    GameObject bullet;
    float curTimeout = 0f;
    float timeoutTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(curTimeout > 0f)
        {
            curTimeout -= Time.deltaTime;
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 position = spawner.position;
            Destroy(Instantiate(bullet, position, Quaternion.identity), 3);
            curTimeout = timeoutTime;
        }
    }
}
