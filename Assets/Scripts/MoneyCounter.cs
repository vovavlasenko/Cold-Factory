using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public int money = 0;
    [SerializeField] private TextMeshProUGUI moneyCountText;


    void Update()
    {
        moneyCountText.SetText(money.ToString()); 
    }
}
