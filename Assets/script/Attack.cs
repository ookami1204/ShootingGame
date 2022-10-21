using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected int attack;
    [SerializeField]
    bool player;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player == false)
        {
            collision.gameObject.GetComponent<PlayerHP>().Damage();
        }
        if (collision.CompareTag("Enemy") && player == true)
        {
            collision.gameObject.GetComponent<HP>().Damage(attack);
        }
    }
}
