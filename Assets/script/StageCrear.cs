using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageCrear : MonoBehaviour
{
    [SerializeField]
    Image crearImage;

    public void Crear()
    {
        crearImage.gameObject.SetActive(true);
    }
}
