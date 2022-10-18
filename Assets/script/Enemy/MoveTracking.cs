using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTracking : Attack
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject effect;
    [SerializeField]
    AudioClip dieSE;
    [SerializeField]
    AudioSource audioSource;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            transform.Rotate(player.transform.position);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag(target))
        {

            Destroy(gameObject);
        }
        if (collision.CompareTag("MovePos"))
        {

            StartCoroutine(Move());
        }
    }
}
