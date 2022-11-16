using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject snowflakePrefab;
    [SerializeField] private GameObject snowballPrefab;
    [SerializeField] private GameObject penguinPrefab;

    public GameObject dialogueButton_3;
    public GameObject firstMergeDoneButton;
    public bool upgradedToSnowballs = false;
    public bool canBeDragged = false;
    public bool firstMerge = true;

    public int spawnTime = 2;
    public bool firstPenguinSpawn = true;

    private bool lessPenguinSpawn = false;
    private bool secondUpgradeSnowballs = false;

    /// <summary>
    /// ��������� �������� �� ����� ������ ��������
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnEverything() 
    {

        for (; ; )
        {
            int randomSpawn = Random.Range(1, 7); // �� ���� ���������� � ������� ���� ������� ����� ������ ������ ����� ������

            if (randomSpawn == 1 || randomSpawn == 2 || (randomSpawn == 3 && !lessPenguinSpawn)) 
            {
                PenguinSpawn();               
            }

            else if ((randomSpawn == 4 && upgradedToSnowballs) || (randomSpawn == 5 && secondUpgradeSnowballs)) 
            {
                SnowballSpawn();
            }

            else 
            {
                SnowflakeSpawn();
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    /// <summary>
    /// ��������� �������� ������ �� ���������� (��� ���������)
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnFlakesOnly()
    { 
        for (; ;)
	    {
            SnowflakeSpawn();
            yield return new WaitForSeconds(spawnTime);
        }
        
    }

    /// <summary>
    /// ��������� ������ �������� (��� ���������)
    /// </summary>
    public void TutorialPenguinSpawn()
    {
         StopAllCoroutines();
         PenguinSpawn();
         firstPenguinSpawn = false;              
    }

    public void PenguinSpawn()
    {
        Instantiate(penguinPrefab, transform.position, Quaternion.identity);
    }

    public void SnowballSpawn()
    {
        Instantiate(snowballPrefab, transform.position, Quaternion.identity);
    }

    public void SnowflakeSpawn()
    {
        Instantiate(snowflakePrefab, transform.position, Quaternion.identity);
    }

    public void MainSpawner()
    {
        StartCoroutine(SpawnEverything());
    }

    public void SpawnOnlyFlakes()
    {
        StartCoroutine(SpawnFlakesOnly());
    }

    public void CanBeDragged()
    {
        canBeDragged = true;
    }

    public void LessPenguins()
    {
        lessPenguinSpawn = true;
    }

    public void AddSnowballs()
    {
        upgradedToSnowballs = true;
    }

    public void MoreSnowBalls()
    {
        secondUpgradeSnowballs = true;
    }

}
