using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeStations : MonoBehaviour
{
    [SerializeField] private MoneyCounter moneyCounterScript;
    [SerializeField] private GameObject button15;
    [SerializeField] private GameObject button16;
    [SerializeField] private GameObject coolingButton;
    [SerializeField] private int increaseStationIncomeValue = 1;
    [SerializeField] private TextMeshProUGUI stationsUpgradeButtonText;

    public int stationsUpgradeCost;

    private HeaderOnOff headerScript;
    private AudioController audioScript;   
    private StationPassiveIncome[] passiveIncomeScripts;
    private int stationsUpgradeNumber = 1;
    private ItemAccept itemAcceptScript;
    private int increaseSnowflakeValue = 1;
    private PolarBearSpawn polarBearScript;
    private bool tutorialUpgrade = true;
    private bool tutorialPassed = false;
    private Button thisButton;

    private void Start()
    {
        headerScript = FindObjectOfType<HeaderOnOff>();
        polarBearScript = FindObjectOfType<PolarBearSpawn>();
        passiveIncomeScripts = FindObjectsOfType<StationPassiveIncome>();
        itemAcceptScript = FindObjectOfType<ItemAccept>();
        thisButton = GetComponent<Button>();
        audioScript = FindObjectOfType<AudioController>();

    }

    private void Update() 
    {
        switch (stationsUpgradeNumber) // ������� ��� �������� �������
        {
            case (1):
                stationsUpgradeCost = 30;
                break;
            case (2):
                stationsUpgradeCost = 50;
                break;
            case (3):
                stationsUpgradeCost = 100;
                break;
            case (4):
                stationsUpgradeCost = 175;
                break;
            case (5):
                stationsUpgradeCost = 300;
                break;
            case (6):
                stationsUpgradeCost = 500;
                break;
            case (7):
                stationsUpgradeCost = 750;
                break;
            case (8):
                stationsUpgradeCost = 1000;
                break;
            case (9):
                stationsUpgradeCost = 1500;
                break;
            case (10):
                stationsUpgradeCost = 3500;
                break;
            case (11):
                stationsUpgradeCost = 5500;
                break;
            case (12):
                stationsUpgradeCost = 8000;
                break;
            case (13):
                stationsUpgradeCost = 12000;
                break;
            case (14):
                stationsUpgradeCost = 17000;
                break;
            case (15):
                stationsUpgradeCost = 25000;
                break;
            case (16):
                stationsUpgradeCost = 35000;
                break;
            case (17):
                stationsUpgradeCost = 50000;
                break;
            case (18):
                stationsUpgradeCost = 70000;
                break;
            case (19):
                stationsUpgradeCost = 100000;
                break;
            case (20):
                stationsUpgradeCost = 150000;
                break;
        }

        if (stationsUpgradeNumber < 21)
            stationsUpgradeButtonText.SetText($"�������� ������� \n��. {stationsUpgradeNumber}->{stationsUpgradeNumber + 1}\n({stationsUpgradeCost} FC$)");

        else
            stationsUpgradeButtonText.SetText("����. �������");


        if (moneyCounterScript.money < stationsUpgradeCost || tutorialPassed == false || stationsUpgradeNumber > 20)
        {
            thisButton.interactable = false;
        }

        else thisButton.interactable = true;
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    public void StationsUpgrade()
    {
        if (tutorialUpgrade == true) // ���� ��� ��������� ��� ��������� - ����������� ������ ���������
        {
            headerScript.HeaderOn();
            coolingButton.SetActive(true);
            button15.SetActive(false);
            button16.SetActive(true);
            tutorialUpgrade = false;
        }

        moneyCounterScript.money -= stationsUpgradeCost; // �������� �� ������ ���-�� �������� ��������� ���������
            stationsUpgradeNumber++; // �������������� ���������� ����� ���������

            for (int i = 0; i < passiveIncomeScripts.Length; i++) // ����������� ������� � ������ �� ������� ���������� ������
            {
                passiveIncomeScripts[i].incomeValue += increaseStationIncomeValue;
            }

            itemAcceptScript.incomeForLvl1Item += increaseSnowflakeValue; // ����������� ������� � �������������� ���� 

            polarBearScript.bearValue++; // ����������� ������� � ���� �� �������

            increaseSnowflakeValue++; // ����������� ���, � ������� ����� ����� �������

        audioScript.BuildStationSound();

    }

    public void TutorialPassed()
    {
        tutorialPassed = true;
    }

}
