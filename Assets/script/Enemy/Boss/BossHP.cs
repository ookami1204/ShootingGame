using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    int CoreNum, effectNum;
    [SerializeField]
    float effectTime;
    [SerializeField]
    GameObject effect;
    [SerializeField]
    GameObject[] taile;
    [SerializeField]
    MoveShark move;
    [SerializeField]
    StageCrear stageCrear;
    [SerializeField]
    EnemyShot enemyShot;
    int destroyCoreNum;

    public void Damage(int damage)
    {
        destroyCoreNum++;
        if(destroyCoreNum == CoreNum)
        {
            move.enabled = false;
            enemyShot.Stop();
            StartCoroutine(Die());
            StartCoroutine(TaileDie());
        }
    }
    IEnumerator TaileDie()
    {
        foreach (var obj in taile)
        {
            obj.GetComponent<MoveSharkTail>().Stop();
        }

        foreach (var obj in taile)
        {
            yield return new WaitForSeconds(effectTime/2);
            Instantiate(effect, obj.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
    IEnumerator Die()
    {
        enemyShot.DestroyBullet();
        for (int i = 0; i < effectNum; i++)
        {
            yield return new WaitForSeconds(effectTime);
            Instantiate(effect, RandomInsPos(), Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);
        stageCrear.Crear();
    }

    Vector2 RandomInsPos()
    {
        Vector2 pos;
        pos.x = Random.Range(transform.position.x - 1, transform.position.x + 1);
        pos.y = Random.Range(transform.position.y - 2.5f, transform.position.y + 2.5f);
        return pos;
    }
}
