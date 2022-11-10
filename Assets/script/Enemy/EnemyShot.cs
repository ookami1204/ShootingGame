using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField]
    public float repeatTime, shotDir;
    [SerializeField]
    int shotNum;
    [SerializeField]
    GameObject bullet, muzlle;

    GameObject[] insBullets;

    Coroutine shot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovePos"))
        {
            shot = StartCoroutine(Shot());
        }
    }

    IEnumerator Shot()
    {
        insBullets = new GameObject[shotNum];
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            for (int i = 0; i < shotNum; i++)
            {
                insBullets[i] = Instantiate(bullet, muzlle.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(shotDir);
            }
        }
    }

    public void Stop()
    {
        StopCoroutine(shot);
    }

    public void DestroyBullet()
    {
        foreach(var obj in insBullets)
        {
            Destroy(obj);
        }
    }
}
