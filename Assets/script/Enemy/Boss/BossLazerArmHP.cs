using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazerArmHP : HP
{
    public GameObject childObj;
    MoveBossArm moveBoss;
    BossLazerShot shot;

    protected override void Start()
    {
        moveBoss = gameObject.GetComponent<MoveBossArm>();
        shot = gameObject.GetComponent<BossLazerShot>();
        base.Start();
    }


    protected override IEnumerator DieProcess()
    {
        moveBoss.StopAllCoroutines();
        shot.StopAllCoroutines();
        yield return InsEffect();
        childObj.transform.SetParent(transform.parent);
        childObj.GetComponent<MoveBossLazerArm2>().Move();
        Destroy(gameObject);
    }
}
