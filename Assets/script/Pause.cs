using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject pauseText;

    bool IsPause;

    void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            IsPause = !IsPause;
            Time.timeScale = IsPause == false ? 0 : 1;
            //pauseText.SetActive(IsPause);
        }
    }
}
