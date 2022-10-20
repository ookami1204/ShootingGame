using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLazer : MonoBehaviour
{
    public GameObject predict;
    public float repeartTime, targetDis;
    public int attack;
    GameObject player, insObj;
    List<RaycastHit2D> hit = new List<RaycastHit2D>();
    Vector3 targetPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating(nameof(Shot), 0, repeartTime);
    }

    void Shot()
    {
        if (ShotDirection().magnitude < targetDis)
        {
            insObj = Instantiate(predict, InsPos(), Quaternion.Euler(GetAngle()));
            StartCoroutine(nameof(LazerAttack));
        }
    }

    IEnumerator LazerAttack()
    {
        yield return new WaitForSeconds(0.75f);
        ChangeColor(insObj, Color.red);
        yield return new WaitForSeconds(0.15f);
        foreach(RaycastHit2D hit in Physics2D.RaycastAll(transform.position, targetPos, 20))
        {
            if(hit.collider != null && hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<PlayerHP>().Damage();
            }
            Destroy(insObj);
        }
    }

    void ChangeColor(GameObject obj, Color color)
    {
        obj.GetComponent<SpriteRenderer>().color = color;
    }

    Vector3 CenterPos(GameObject target)
    {
        return (transform.position + target.transform.position) / 2;
    }

    Vector3 GetAngle()
    {
        var dt = ShotDirection();
        var rad = Mathf.Atan2(dt.y, dt.x);
        return new Vector3(0,0, rad * Mathf.Rad2Deg);
    }

    Vector3 ShotDirection()
    {
        targetPos = player.transform.position - transform.position;
        return targetPos;
    }

    Vector3 InsPos()
    {
        var angle =  GetAngle().z * Mathf.PI / 180;
        var insPos = new Vector3(10 * Mathf.Cos(angle), 10 * Mathf.Sin(angle), 0);
        insPos += transform.position;
        return insPos;
    }
}