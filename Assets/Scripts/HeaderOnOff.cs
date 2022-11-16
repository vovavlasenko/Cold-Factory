using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderOnOff : MonoBehaviour
{
    public GameObject header;
    public GameObject arrowButton;


    void Start()
    {
        HeaderOn();
    }

    /// <summary>
    /// Включение надписи "Ледяной король" и мигающей иконки стрелочки
    /// </summary>
    public void HeaderOn()
    {
        header.SetActive(true);
        arrowButton.SetActive(true);
    }

    /// <summary>
    /// Выключение надписи "Ледяной король" и мигающей иконки стрелочки
    /// </summary>
    public void HeaderOff()
    {
        header.SetActive(false);
        arrowButton.SetActive(false);
    }
}
