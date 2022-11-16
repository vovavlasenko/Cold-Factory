using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAccept : MonoBehaviour
{
    public int incomeForLvl1Item = 1;
    public int lossForPenguin;

    private MoneyCounter moneyCounterScript;
    private new AudioController audio;
    private BoundDestroyer boundScript;
    private ItemSpawner itemSpawnerScript;
    
    
    void Start()
    {
        moneyCounterScript = FindObjectOfType<MoneyCounter>();
        audio = FindObjectOfType<AudioController>();
        boundScript = FindObjectOfType<BoundDestroyer>();
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
    }

    void Update()
    {
        lossForPenguin = incomeForLvl1Item * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Когда объект доплывает по реке до станции, выполняется соответствующее условие
    {

        if (collision.gameObject.CompareTag("Copy")) 
        {
            collision.gameObject.tag = collision.gameObject.GetComponent<Drag>().clone.tag;
            Destroy(collision.gameObject.GetComponent<Drag>().clone);                      
        }

        if (collision.gameObject.CompareTag("1_LVL_ITEM"))
        {
            moneyCounterScript.money += incomeForLvl1Item;                     
        }


        if (collision.gameObject.CompareTag("2_LVL_ITEM"))
        {
            moneyCounterScript.money += incomeForLvl1Item * 3;          
        }

        if (collision.gameObject.CompareTag("3_LVL_ITEM"))
        {
            moneyCounterScript.money += incomeForLvl1Item * 7;
        }

        if (collision.gameObject.CompareTag("Penguin"))
        {
            moneyCounterScript.money -= lossForPenguin;

            if (boundScript.tutorialPenguinDestroyed == false) // Если в процессе туториала игрок не уничтожил пингвина, спавним еще одного
            {
                itemSpawnerScript.firstPenguinSpawn = true;
                itemSpawnerScript.TutorialPenguinSpawn();
            }
        }

        audio.StationReceiveSound();
        Destroy(collision.gameObject); // После чего объект уничтожается
    }



}
