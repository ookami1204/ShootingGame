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

    int MaxHP = 5;
    int currentHP = 5;

    void Start()
    {

    }

    public void Damage()
    {
        currentHP--;
        HP[currentHP].gameObject.SetActive(false);
        if (currentHP <= 0)
        {
            PlayerDie();
            StartCoroutine(DieProcess());
        }
    }

    void PlayerDie()
    {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("wall"))
        {
            currentHP--;
            HP[currentHP].gameObject.SetActive(false);
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
