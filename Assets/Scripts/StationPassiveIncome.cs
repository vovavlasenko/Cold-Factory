using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationPassiveIncome : MonoBehaviour
{
    public float incomeTime;
    public int incomeValue;

    private MoneyCounter moneyScript;

    void Start()
    {
        moneyScript = GameObject.FindObjectOfType<MoneyCounter>();
        StartCoroutine(PassiveIncome());
    }

    /// <summary>
    /// Пассивный доход со станций
    /// </summary>
    /// <returns></returns>
    private IEnumerator PassiveIncome()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(incomeTime);
            moneyScript.money += incomeValue;
        }
    }

}
