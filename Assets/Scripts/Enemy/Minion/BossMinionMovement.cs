using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossMinionMovement : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Transform transform;
    protected float speed = 5f;
    protected private Vector3 targetPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        targetPosition = new Vector3(-100, transform.position.y, transform.position.z);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        // move to the left
        base.transform.position = Vector3.MoveTowards(base.transform.position, targetPosition, speed * Time.deltaTime);
    }
}
