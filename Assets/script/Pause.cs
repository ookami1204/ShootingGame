using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject pauseText;

    bool IsPause = false;

    void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = IsPause == false ? 0 : 1;
            IsPause = !IsPause;
            //pauseText.SetActive(IsPause);
        }
    }
}
