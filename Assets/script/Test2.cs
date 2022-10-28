using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField]
    GameObject test;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    bool A;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (A == true && collision.CompareTag("wall"))
        {
            rb.gravityScale = 0;
            test.transform.eulerAngles = new Vector3(0, 0, test.transform.eulerAngles.z + 90);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (A == false && collision.CompareTag("wall"))
        {
            rb.gravityScale = 10;
            test.transform.eulerAngles = new Vector3(0, 0, test.transform.eulerAngles.z - 90);
        }
    }
}
