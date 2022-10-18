using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazerHP : HP
{
    [SerializeField]
    Transform core;
    [SerializeField]
    GameObject[] cores;
    [SerializeField]
    GameObject[] arms;

    GameObject coreObj;

    protected override void Start()
    {
        base.Start();
        CoreIns(0);
    }

    public override void Damage(int attack)
    {
        currentHP -= attack;
        if (currentHP <= MaxHP / 3 * 2 && currentHP > MaxHP / 3)
        {
            Destroy(coreObj);
            CoreIns(1);
        }
        if (currentHP <= MaxHP / 3)
        {
            Destroy(coreObj);
            CoreIns(2);
        }
        if (currentHP <= 0)
        {
            StartCoroutine(DieProcess());
        }        
    }

    void CoreIns(int i)
    {
        coreObj = Instantiate(cores[i], core.position, Quaternion.identity, transform);
    }
}
