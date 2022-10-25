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
    [SerializeField]
    float backSpeed;

    bool IsPush;
    bool IsBack;
    bool IsRight = true;

    Coroutine moveVertical;
    Coroutine moveWidth;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, mainCamera.transform.position.x - 8f,
                                                                            mainCamera.transform.position.x + 8f),
                                         Mathf.Clamp(transform.position.y, mainCamera.transform.position.y - 4.5f,
                                                                            mainCamera.transform.position.y + 4.5f));
        if(IsPush == false)
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
        if (Input.GetButtonDown("ShotForce"))
        {
            rb.velocity = Vector2.zero;
            if(IsPush == true)
            {
                StopAllCoroutines();
                StartCoroutine(Back());
            }
            else
            {
                IsPush = true;
                if (IsRight)
                {
                    rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
                }
            }
            moveVertical = StartCoroutine(MoveVertical());
        }
    }

    IEnumerator Back()
    {
        IsBack = true;
        while(IsPush == true)
        {
            yield return new WaitForEndOfFrame();
            rb.velocity = (player.transform.position - transform.position).normalized * backSpeed;
        }
    }
    IEnumerator MoveWidth()
    {
        float movePos;
        if (IsRight)
        {
            movePos = mainCamera.transform.position.x + 7 - transform.position.x;
        }
        else
        {
            movePos = mainCamera.transform.position.x - 7 - transform.position.x;
        }
        while (movePos > 0.25f)
        {
            yield return new WaitForEndOfFrame();
            rb.velocity = new Vector2(movePos, rb.velocity.y).normalized * speed;
        }
        rb.velocity = Vector2.zero;
    }
    IEnumerator MoveVertical()
    {
        while (IsPush)
        {
            yield return new WaitForSeconds(4);
            while (Mathf.Abs(player.transform.position.y - transform.position.y) > 0.25f)
            {
                yield return new WaitForEndOfFrame();
                rb.velocity = new Vector2(rb.velocity.x, player.transform.position.y - transform.position.y).normalized * speed;
            }
            rb.velocity = Vector2.zero;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && IsBack == false)
        {
            rb.velocity = Vector2.zero;
            moveWidth = StartCoroutine(MoveWidth());
            Instantiate(effect, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        if (collision.gameObject.CompareTag("Player") && IsPush == true)
        {
            IsBack = false;
            IsPush = false;
            if (transform.position.x > player.transform.position.x)
            {
                IsRight = true;
                transform.position = new Vector2(player.transform.position.x + 0.8f, player.transform.position.y);
            }
            else
            {
                IsRight = false;
                transform.position = new Vector2(player.transform.position.x - 0.8f, player.transform.position.y);
            }
        }
    }
}
