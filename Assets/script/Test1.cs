using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D rb;
        
    LayerMask layerMask;
    RaycastHit2D hitRight, hitDown;

    bool AA;

    void Start()
    {
        layerMask = LayerMask.GetMask("wall");
    }

    void Update()
    {
        rb.velocity = transform.right * speed;

        Vector2 origin = transform.position;
        hitRight = Physics2D.Raycast(origin, transform.right, 0.15f, layerMask);
        Debug.DrawRay(transform.position, transform.right * 0.15f, Color.red);
        if (hitRight)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 90);
        }

        Vector2 rightOffset = transform.right * 0.15f;
        hitDown = Physics2D.Raycast(origin - rightOffset, transform.up * -1, 0.5f, layerMask);
        Debug.DrawRay(transform.position - transform.right * 0.15f, transform.up * -1 * 0.5f, Color.red);
        if (!hitDown && AA == true)
        {
            AA = false;
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
        }
        else if(hitDown && AA == false)
        {
            AA = true;
            transform.position = hitDown.point + hitDown.normal * 0.15f + rightOffset;
        }
    }
}
