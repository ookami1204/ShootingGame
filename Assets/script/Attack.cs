using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected int attack;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHP>().Damage();
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HP>().Damage(attack);
        }
    }
}
