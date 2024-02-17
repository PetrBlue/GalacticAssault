using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossMovement : EnemyMovement
{
    public BossMovement()
    {
        minY = -3.5f;
        maxY = 3.5f;
    }
    public override void Update()
    {
        MoveToTarget();
    }
    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
    }
}