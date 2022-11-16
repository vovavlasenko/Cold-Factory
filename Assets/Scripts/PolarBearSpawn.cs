using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarBearSpawn : MonoBehaviour
{
    [SerializeField] private GameObject polarBearPrefab;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] private int timeToDestroy = 4;
    [SerializeField] private GameObject buttonShow;
    [SerializeField] private GameObject buttonHide;


    public float bearSpawnDelay = 30f;
    public int bearValue = 1;
    public int bearValueMultiplier = 1;

    private HeaderOnOff headerScript;

    private void Start()
    {
        headerScript = FindObjectOfType<HeaderOnOff>();
    }

    public void TutorialBearSpawn()
    {
        StartCoroutine(TutorialPolarBearSpawn());
    }

    /// <summary>
    /// Запускаем бесконечный цикл создания медведей через определенный промежуток времени
    /// </summary>
    /// <returns></returns>
    IEnumerator BearSpawn()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(bearSpawnDelay);
            int positionNumber = Random.Range(0, 4);
            GameObject bearClone = Instantiate(polarBearPrefab, spawnPositions[positionNumber].position, Quaternion.identity);
            Destroy(bearClone, timeToDestroy);
        }
    }

    /// <summary>
    /// Создание первого тренировочного медведя для туториала
    /// </summary>
    /// <returns></returns>
    IEnumerator TutorialPolarBearSpawn()
    {
        GameObject bearClone = Instantiate(polarBearPrefab, spawnPositions[0].position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        Destroy(bearClone);
        headerScript.HeaderOn();
        buttonHide.SetActive(false);
        buttonShow.SetActive(true);
        StartCoroutine(BearSpawn());
    }

    /// <summary>
    /// Апгрейд для увеличения частоты создания медведей
    /// </summary>
    public void MoreOfterBearSpawn()
    {
        bearSpawnDelay = 20f;
    }

    /// <summary>
    /// Апгрейд для увеличения кол-ва коинов за тап по медведю
    /// </summary>
    public void MultiplyBearValue()
    {
        bearValueMultiplier++;
    }

}
