using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationBuild : MonoBehaviour
{
    [SerializeField] private GameObject riverStation;
    [SerializeField] private GameObject incomeStationPrefab;
    [SerializeField] private Transform[] buildPosition;
    [SerializeField] private GameObject dialogueButton_1;
    [SerializeField] private GameObject dialogueButton_2;
    [SerializeField] private GameObject dialogueButton_3;
    [SerializeField] private GameObject quest_1;
    [SerializeField] private GameObject quest_2;
    [SerializeField] private Button buildStationButton;
    [SerializeField] private GameObject upgradeStationButton;

    private HeaderOnOff headerScript;
    private int stationNumber = 0;

    private void Start()
    {
        headerScript = FindObjectOfType<HeaderOnOff>();
    }

    /// <summary>
    /// Построить станцию
    /// </summary>
    public void BuildStation() 
    {
        if (stationNumber < 3)
        {
            if (stationNumber == 0)
            {
                dialogueButton_1.SetActive(true);
                quest_1.SetActive(false);
                buildStationButton.interactable = false;
                headerScript.HeaderOn();
            }

            if (stationNumber == 2)
            {
                dialogueButton_2.SetActive(true);
                quest_2.SetActive(false);
                buildStationButton.interactable = false;
                headerScript.HeaderOn();
            }

            Instantiate(incomeStationPrefab, buildPosition[stationNumber].position, Quaternion.identity);
            stationNumber++;
        }

        else 
        {
            riverStation.SetActive(true);
            buildStationButton.gameObject.SetActive(false);
            dialogueButton_2.SetActive(false); 
            dialogueButton_3.SetActive(true);
            headerScript.HeaderOn();
            upgradeStationButton.SetActive(true);
        }  

    }
}
