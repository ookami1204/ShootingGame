using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazerShot : MonoBehaviour
{
    public Transform[] muzlle;
    public GameObject bullet;
    public float shotDirection;

    void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        while (true)
        {
            for (int i = 0; i < muzlle.Length; i++)
            {
                yield return new WaitForSeconds(shotDirection /2);
                Instantiate(bullet, muzlle[i].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(shotDirection);
        }
    }
}
