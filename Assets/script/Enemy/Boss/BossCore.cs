using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCore : HP
{
    public GameObject MainBody;

    public override void Damage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
            MainBody.GetComponent<BossHP>().Damage(1);
    }
}
