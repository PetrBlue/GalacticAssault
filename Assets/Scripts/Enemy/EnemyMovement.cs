using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Transform transform;
    protected float speed = 2f;
    protected float minY = -2.5f;
    protected float maxY = 2.5f;
    protected float curTimeout = 3f;
    protected float minTimeout = 2f;
    protected float maxTimeout = 5f;
    protected float timeoutChance = 0.001f; // procents
    protected bool moving = false;
    protected private Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        targetPosition = GetRandomPosition();
    }

    public virtual void Update()
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
        base.transform.position = Vector3.MoveTowards(base.transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(base.transform.position, targetPosition) < 0.01f)
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
            moving = true;
            targetPosition = GetRandomPosition();
            curTimeout = Random.Range(minTimeout, maxTimeout);
        }
    }

    void StartTimeout()
    {
        moving = false;
        curTimeout = Random.Range(minTimeout, maxTimeout);
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(base.transform.position.x, Random.Range(minY, maxY), base.transform.position.z);
    }
}
