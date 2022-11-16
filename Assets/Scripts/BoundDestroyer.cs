using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDestroyer : MonoBehaviour
{  
    [SerializeField] private GameObject tutorialButton_show;
    [SerializeField] private GameObject tutorialButton_hide;

    public bool tutorialPenguinDestroyed; // ��������� �� ������� � ��������

    private HeaderOnOff headerScript;
    private ItemSpawner itemSpawnerScript;
    private new AudioController audio;


    void Start()
    {
        audio = FindObjectOfType<AudioController>();
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
        headerScript = FindObjectOfType<HeaderOnOff>();
    }


    private void OnCollisionEnter2D(Collision2D collision) // ��� �������������� ������� �� ������� ����, ���������� ��������
    {
        if (collision.gameObject.CompareTag("Penguin"))
        {
            audio.PenguinSound();

            if (tutorialPenguinDestroyed == false) // ���� ����� ���������� �������� �� ������ �� �������� - ����������� ������ ��������
            {
                tutorialButton_hide.SetActive(false);
                tutorialButton_show.SetActive(true);
                headerScript.HeaderOn();
                tutorialPenguinDestroyed = true;
                itemSpawnerScript.MainSpawner();
            }
        }

        Destroy(collision.gameObject); // ����������� �������
    }
}
