using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSharkTail : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 1;
    [SerializeField]
    float MaxRotate;
    [SerializeField]
    float MinRotate;
    [SerializeField]
    float waitTime;

    float nowSpeed;
    Vector3 rotate;
    bool IsUp = true;
    Coroutine MoveCoroutine;

    void Start()
    {
        nowSpeed = rotateSpeed;
        rotate = transform.localEulerAngles;
        //rotate.z = -(1 / (MaxRotate + MinRotate)) * rotateSpeed;
        MoveCoroutine = StartCoroutine(nameof(Move));
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            yield return null;
            transform.eulerAngles += nowSpeed * Time.deltaTime * Vector3.forward;
            if ((ChangeAngle() > MaxRotate && IsUp == true))
            {
                Debug.Log("A");
                nowSpeed = -rotateSpeed;
                IsUp = false;
            }
            if(ChangeAngle() < MinRotate && IsUp == false)
            {
                Debug.Log("B");
                nowSpeed = rotateSpeed;
                IsUp = true;
            }
        }
    }

    float ChangeAngle()
    {
        var rotate = transform.localEulerAngles.z;
        if (rotate > 180)
        {
            rotate -= 360;
        }

        return rotate;
    }

    public void Stop()
    {
        StopCoroutine(MoveCoroutine);
    }
}
