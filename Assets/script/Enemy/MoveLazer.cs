
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLazer : Attack
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected bool IsstartUP = true;
    [SerializeField]
    protected float speedX, speedY;
    [SerializeField]
    protected Vector2 pos;
    List<Vector2> originPos = new List<Vector2>();
    [SerializeField]
    EdgeCollider2D edgeCollider;
    [SerializeField]
    TrailRenderer trailRenderer;

    void Start()
    {
        speedX = speedY = speed;
        if (IsstartUP)
            speedY *= -1;
        pos = transform.position;
        Destroy(this.gameObject, 3);
    }

    protected virtual void Update()
    {
        MovePos();
        ColliderCrate();
    }

    void ColliderCrate()
    {
        for(int i = 0; i < trailRenderer.positionCount; i++)
        {
            originPos.Add(trailRenderer.GetPosition(i));
            originPos[i] -= (Vector2)transform.position;
        }
        edgeCollider.points = originPos.ToArray();
        originPos.Clear();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("wall"))
        {
            speedX *= -1;
        }

        if (collision.CompareTag("floor"))
        {
            speedY *= -1;
        }
    }

    void MovePos()
    {
        pos.x += speedX * Time.deltaTime;
        pos.y += speedY * Time.deltaTime;
        transform.position = pos;
    }
}
