using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Trisibo;

public class StageCrear : MonoBehaviour
{
    [SerializeField]
    SceneField loadScene;
    [SerializeField]
    Image image;

    public void Crear()
    {
        if(loadScene != null)
        {
            SceneManager.LoadScene(loadScene.BuildIndex);
        }
        else
        {
            image.gameObject.SetActive(true);
        }
    }
}
