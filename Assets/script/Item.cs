using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ItemStatus
{
    [SerializeField]
    ItemKinds itemKinds;
    [SerializeField]
    AudioClip SE;
    [SerializeField]
    AudioSource audioSource;

    GameObject Player;
    GameObject PlayerStatus;

    void Start()
    {
        // TODO : 参照の取得方法の変更
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerStatus = GameObject.FindGameObjectWithTag("PlayerStatus");
        audioSource = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(SE);
            Destroy(gameObject);
        }
    }

    public void StatusUP()
    {
        switch (itemKinds)
        {
            case ItemKinds.CurrentHP:
                Player.GetComponent<PlayerHP>().Recovery(1);
                break;
            case ItemKinds.Bullet:
                PlayerStatus.GetComponent<PlayerStatus>().StatusUP(itemKinds);
                break;
            case ItemKinds.Muzzlu:
                PlayerStatus.GetComponent<PlayerStatus>().StatusUP(itemKinds);
                break;
            case ItemKinds.Charge:
                PlayerStatus.GetComponent<PlayerStatus>().StatusUP(itemKinds);
                break;
        }
    }
}
