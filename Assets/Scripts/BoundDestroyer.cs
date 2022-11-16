using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDestroyer : MonoBehaviour
{  
    [SerializeField] private GameObject tutorialButton_show;
    [SerializeField] private GameObject tutorialButton_hide;

    public bool tutorialPenguinDestroyed; // Уничтожен ли пингвин в обучении

    private HeaderOnOff headerScript;
    private ItemSpawner itemSpawnerScript;
    private new AudioController audio;


    void Start()
    {
        audio = FindObjectOfType<AudioController>();
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
        headerScript = FindObjectOfType<HeaderOnOff>();
    }


    private void OnCollisionEnter2D(Collision2D collision) // При перетаскивании объекта за пределы реки, произойдет коллизия
    {
        if (collision.gameObject.CompareTag("Penguin"))
        {
            audio.PenguinSound();

            if (tutorialPenguinDestroyed == false) // Если игрок уничтожает пингвина по квесту из обучения - переключаем слайды обучения
            {
                tutorialButton_hide.SetActive(false);
                tutorialButton_show.SetActive(true);
                headerScript.HeaderOn();
                tutorialPenguinDestroyed = true;
                itemSpawnerScript.MainSpawner();
            }
        }

        Destroy(collision.gameObject); // Уничтожение объекта
    }
}
