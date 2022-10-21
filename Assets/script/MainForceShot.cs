using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainForceShot : MonoBehaviour
{
    [SerializeField]
    GameObject[] bullet;
    [SerializeField]
    GameObject[] muzlle;

    [SerializeField]
    float coolTime;

    void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetButtonDown("ShotButton"));
            for(int i = 0; i < muzlle.Length; i++)
            {
                Instantiate(bullet[i], muzlle[i].transform.position, muzlle[i].transform.rotation);
            }
        }
    }
}
