using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 飛ばしたら、何かに当たったら飛ばした方向の規定値に行こうとする
// 一定時間でプレイヤーの高さに合わせる

public class MainForce : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    GameObject effect;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed;

    bool Ispush;

    void Start()
    {
        
    }

    void Update()
    {
        if(Ispush == false)
        {
            if (transform.position.x > player.transform.position.x)
            {
                transform.position = new Vector2(player.transform.position.x + 0.8f, player.transform.position.y);
            }
            else
            {
                transform.position = new Vector2(player.transform.position.x - 0.8f, player.transform.position.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(Ispush == true)
            {
                rb.velocity = Vector2.zero;
                StartCoroutine(Back());
            }
            else
            {
                rb.velocity = Vector2.zero;
                Ispush = true;
                if (transform.position.x > player.transform.position.x)
                {
                    rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
            }
        }
    }

    IEnumerator Back()
    {
        while(Ispush == true)
        {
            Debug.Log(rb.velocity.magnitude);
            yield return new WaitForEndOfFrame();
            //一定速度で戻る処理
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //Instantiate(effect, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
        }
        if (collision.CompareTag("Player") && Ispush == true)
        {
            Ispush = false;
            if(transform.position.x > player.transform.position.x)
            {
                transform.position = new Vector2(player.transform.position.x + 0.8f, player.transform.position.y);
            }
            else
            {
                transform.position = new Vector2(player.transform.position.x - 0.8f, player.transform.position.y);
            }
        }
    }
}
