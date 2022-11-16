using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private GameObject nextLvl_Item_prefab;

    private int ID;
    private ItemSpawner itemSpawnerScript;
    private new AudioController audio;
    private HeaderOnOff headerScript;

    void Start()
    {
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
        audio = FindObjectOfType<AudioController>();
        headerScript = FindObjectOfType<HeaderOnOff>();
        ID = GetInstanceID();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� � �������� ���������� ���� - ��� �������� ��������� �������
        if (collision.gameObject.tag == gameObject.tag) 
        {
            if (ID < collision.gameObject.GetInstanceID()) // ������� ������ ���� ������� ������ ����� ��������, ����� ����� ���������
            {
                // ���������� ��� ������� � �����, ������� ����� ���������� ������
                Destroy(collision.gameObject);
                MergeItems();
                Destroy(gameObject);
                GameObject copy = GameObject.FindGameObjectWithTag("Copy");
                Destroy(copy);
            }
        }
    }

    /// <summary>
    /// ������� ���� ���������� ��������
    /// </summary>
    private void MergeItems()
    {
        if (itemSpawnerScript.firstMerge == true)
        {
            FirstMergeCompleted();
        }

        Instantiate(nextLvl_Item_prefab, transform.position, Quaternion.identity);

        audio.MergeSound();

    }

    private void FirstMergeCompleted() // ���� ��� ������ ������� (� ������ ��������) - ������ ������ ��������
    {
        itemSpawnerScript.firstMerge = false;
        itemSpawnerScript.dialogueButton_3.SetActive(false);
        itemSpawnerScript.firstMergeDoneButton.SetActive(true);
        headerScript.HeaderOn();

    }
}
