using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    Image[] HP = new Image[5];
    [SerializeField]
    PlayerStatus status;
    [SerializeField]
    Image gameOverImage;
    [SerializeField]
    int effectNum;
    [SerializeField]
    float effectInterval;
    [SerializeField]
    GameObject effect;
    [SerializeField]
    BoxCollider2D boxcollider;
    [SerializeField]
    GameObject destroyPos;

    [SerializeField]
    AudioClip damageSE;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip dieBGM;
    [SerializeField]
    AudioSource BGMSouse;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    int MaxHP = 5;
    int currentHP = 5;
    bool IsFlashing = false;

    void Start()
    {

    }

    IEnumerator Flashing()
    {
        IsFlashing = true;
        Color defoltColor = spriteRenderer.color;
        for(int i = 0; i < 6; i++)
        {
            spriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = defoltColor;
            yield return new WaitForSeconds(0.1f);
        }
        IsFlashing = false;
    }

    public void Damage()
    {
        if (IsFlashing == true)
        {
            return;
        }
        StartCoroutine(Flashing());
        audioSource.PlayOneShot(damageSE);
        currentHP--;
        HP[currentHP].gameObject.SetActive(false);
        if (currentHP <= 0)
        {
            PlayerDie();
            BGMSouse.Stop();
            BGMSouse.PlayOneShot(dieBGM);
            StartCoroutine(DieProcess());
        }
    }

    void PlayerDie()
    {
        Time.timeScale = 0;
        gameOverImage.gameObject.SetActive(true);
    }

    public void Recovery(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, MaxHP);
        for(int i = 0; i < currentHP; i++)
        {
            HP[i].gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("wall"))
        {
            Damage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == destroyPos)
        {
            PlayerDie();
            StartCoroutine(DieProcess());
        }
    }

    IEnumerator DieProcess()
    {
        var effectArea = (Vector2)transform.position + boxcollider.offset;
        Vector2 insPos;
        for(int i = 0; i < effectNum; i++)
        {
            yield return new WaitForSeconds(effectInterval);
            insPos.x = Random.Range(effectArea.x - 0.5f, effectArea.x + 0.5f);
            insPos.y = Random.Range(effectArea.y - 0.5f, effectArea.y + 0.5f);
            Instantiate(effect, insPos, Quaternion.identity);
        }
    }
}
