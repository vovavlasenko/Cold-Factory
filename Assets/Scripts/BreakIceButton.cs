using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakIceButton : MonoBehaviour
{
    [SerializeField] private GameObject upgradeRiverButton;
    [SerializeField] private GameObject dialogueButton_1;
    [SerializeField] private GameObject dialogueButton_2;

    private MoneyCounter moneyCounterScript;
    private Button thisButton;
    private ItemSpawner itemSpawnerScript;
    private HeaderOnOff headerScript;


    void Start()
    {
        moneyCounterScript = FindObjectOfType<MoneyCounter>();
        thisButton = GetComponent<Button>();
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
        headerScript = FindObjectOfType<HeaderOnOff>();
    }


    void Update()
    {
        if (moneyCounterScript.money < 5)
        {
            thisButton.interactable = false;
        }

        else thisButton.interactable = true;
    }

    /// <summary>
    /// ��������� ��� �� ���� � ��������� ��������
    /// </summary>
    public void BreakIce()
    {
        itemSpawnerScript.SpawnOnlyFlakes();
        moneyCounterScript.money -= 5;
        dialogueButton_1.SetActive(false); // ����������� ������ ���������
        dialogueButton_2.SetActive(true);
        headerScript.HeaderOn();
        this.gameObject.SetActive(false);
    }
}