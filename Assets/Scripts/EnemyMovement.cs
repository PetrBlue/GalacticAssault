using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Transform transfrom;
    float speed = 2f;
    float minY = -2.5f;
    float maxY = 2.5f;
    float curTimeout = 3f;
    float minTimeout = 2f;
    float maxTimeout = 5f;
    float timeoutChance = 0.001f; // procents
    bool moving = false;
    private Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transfrom = GetComponent<Transform>();
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        if (moving)
        {
            MoveToTarget();
        }
        else
        {
            HandleTimeout();
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            targetPosition = GetRandomPosition();
        }
        if (Random.value < timeoutChance)
        {
            StartTimeout();
        }
    }

    void HandleTimeout()
    {
        curTimeout -= Time.deltaTime;

        if (curTimeout <= 0f)
        {
            // Reset timer and resume movement
            moving = true;
            targetPosition = GetRandomPosition();
            curTimeout = Random.Range(minTimeout, maxTimeout);
        }
    }

    void StartTimeout()
    {
        // Start timeout and stop movement
        moving = false;
        curTimeout = Random.Range(minTimeout, maxTimeout);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
    }
}
