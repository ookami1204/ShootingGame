using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot : MonoBehaviour
{

    [SerializeField]
    PlayerStatus status;
    [SerializeField]
    Slider slider_Charge;
    [SerializeField]
    GameObject chargeEffect;
    [SerializeField]
    GameObject[] bullet;
    [SerializeField]
    GameObject[] chargeBullet;
    [SerializeField]
    GameObject[] muzzle;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip chargeSE;
    [SerializeField]
    AudioClip shotSE;
    [SerializeField]
    AudioClip chargeShotSE;

    GameObject chargeObj;
    float time;
    bool IsCharge;

    void Start()
    {
        slider_Charge.value = 0;
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetButtonDown("ShotButton"))
        {
            time = 0;
            chargeObj = Instantiate(chargeEffect, muzzle[0].transform.position, Quaternion.identity);
        }
        if (Input.GetButton("ShotButton"))
        {
            time += Time.deltaTime;
            slider_Charge.value = time / status.ChargeTime;
            chargeObj.transform.position = muzzle[0].transform.position;
            if(time > 0.2f && IsCharge == false)
            {
                IsCharge = true;
                audioSource.PlayOneShot(chargeSE);
            }
        }
        else
        {
            slider_Charge.value = 0;
            Destroy(chargeObj);
        }
        if (Input.GetButtonUp("ShotButton"))
        {
            IsCharge = false;
            Destroy(chargeObj);
            audioSource.Stop();
            slider_Charge.value = 0;
            if(time < status.ChargeTime)
            {
                audioSource.PlayOneShot(shotSE);
                Shot(bullet[status.BulletLevel]);
            }
            if (time > status.ChargeTime)
            {
                audioSource.PlayOneShot(chargeShotSE);
                Shot(chargeBullet[status.BulletLevel]);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bullet"></param>
    void Shot(GameObject bullet)
    {
        for(int i = 0; i < status.MuzzleLevel; i++)
        {
            //生成時の角度指定
            Instantiate(bullet, muzzle[i].transform.position, Quaternion.identity);
        }
    }
}
