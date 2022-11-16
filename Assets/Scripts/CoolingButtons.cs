using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolingButtons : MonoBehaviour
{
    [SerializeField] private int coolingCost;
    [SerializeField] private GameObject coolingMessage;

    private MoneyCounter moneyScript;
    private Button thisButton;

    void Start()
    {
        thisButton = GetComponent<Button>();
        moneyScript = FindObjectOfType<MoneyCounter>();
    }

    void Update()
    {
        if (moneyScript.money >= coolingCost)
        {
            thisButton.interactable = true;
        }

        else
            thisButton.interactable = false;
    }

    /// <summary>
    /// ¬ычитание коинов за охлаждение континента, вывод текстового сообщени€
    /// </summary>
    public void Cooling()
    {
        moneyScript.money -= coolingCost;
        coolingMessage.SetActive(true);
    }
}
