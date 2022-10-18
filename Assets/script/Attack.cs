using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected int attack;

    [SerializeField]
    protected string target;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            collision.gameObject.GetComponent<HP>().Damage(attack);
        }
    }
}
