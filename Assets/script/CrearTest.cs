using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearTest : MonoBehaviour
{
    [SerializeField]
    Image image;

    private void OnDestroy()
    {
        image.gameObject.SetActive(true);
    }
}
