using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanelScript : MonoBehaviour // Заполнение информационной панели актуальными данными
{
    public int incomeForSnowflake;
    public int incomeForSnowball;
    public int incomeForSnowman;
    public int incomeForBear;
    public int incomeForStation;
    public int lossForPenguin;

    [SerializeField] private TextMeshProUGUI snowflakeValueText;
    [SerializeField] private TextMeshProUGUI snowballValueText;
    [SerializeField] private TextMeshProUGUI snowmanValueText;
    [SerializeField] private TextMeshProUGUI bearValueText;
    [SerializeField] private TextMeshProUGUI penguinLossText;
    [SerializeField] private TextMeshProUGUI stationValueText;

    private ItemAccept itemAcceptScript;
    private StationPassiveIncome passiveIncomeScript;
    private PolarBearSpawn bearScript;

    void Start()
    {
        itemAcceptScript = FindObjectOfType<ItemAccept>();
        passiveIncomeScript = FindObjectOfType<StationPassiveIncome>();
        bearScript = FindObjectOfType<PolarBearSpawn>();
    }

    void Update()
    {
        incomeForSnowflake = itemAcceptScript.incomeForLvl1Item;
        incomeForSnowball = incomeForSnowflake * 3;
        incomeForSnowman = incomeForSnowflake * 7;
        lossForPenguin = incomeForSnowflake * 2;
        incomeForBear = bearScript.bearValue * bearScript.bearValueMultiplier;
        incomeForStation = passiveIncomeScript.incomeValue;



        snowflakeValueText.SetText($"+{incomeForSnowflake}");
        snowballValueText.SetText($"+{incomeForSnowball}");
        snowmanValueText.SetText($"+{incomeForSnowman}");
        bearValueText.SetText($"x tap +{incomeForBear}");
        penguinLossText.SetText($"-{lossForPenguin}");
        stationValueText.SetText($"x3+{incomeForStation}");
    }
}
