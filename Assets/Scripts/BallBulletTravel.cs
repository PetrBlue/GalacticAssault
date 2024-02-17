using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBulletTravel : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move only forward
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}