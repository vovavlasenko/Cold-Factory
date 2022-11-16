using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool canBeDragged = false;
    public GameObject clone;

    private Vector2 screenPos;
    private Vector2 worldPos;
    private bool isDragging = false;
    private SpriteRenderer sr;
    private ItemSpawner itemSpawnerScript;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        itemSpawnerScript = FindObjectOfType<ItemSpawner>();
    }

    private void OnMouseDown() // Если на объекте висит этот скрипт, нажатие на данный объект дает сигнал к перетаскиванию
    {
        if (itemSpawnerScript.canBeDragged == true) // Если перетаскивание объекта доступно 
        {
            isDragging = true; // Даем сигнал для перетаскивания

            if (gameObject.tag != "Penguin")
            {
                clone = Instantiate(gameObject, transform.position, Quaternion.identity); // Создаем клон, его и будем перетаскивать
                gameObject.layer = 10; 
                gameObject.tag = "Copy";// Сам объект становится копией, связанной с клоном, которая будет продолжать движение по конвейеру
                sr.color = new Color(0.7f, 0.4f, 0.4f, 0.7f); // Копия отличается от клона своим оттенком
            }
        }
    }

    private void OnMouseUp() // При отпускании нажатия
    {
        DragAborted(); // Прерываем перетаскивание
    }

    void Update()
    {
        if (isDragging == true) // Перетаскивание объекта (если это пингвин), или клона (если это объект для которого доступно слияние)
        {
            screenPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);          

            if (clone != null)
                clone.transform.localPosition = new Vector3(worldPos.x, worldPos.y, 0);

            else
                this.gameObject.transform.localPosition = new Vector3(worldPos.x, worldPos.y, 0); 
        }

        if (clone != null && clone.transform.position.x > gameObject.transform.position.x + 1) // Перетаскивать можно только влево
        {
            DragAborted(); // В противном случае прерываем перетаскивание

        }
    }

    private void DragAborted()
    {
        isDragging = false; // Перетаскивание сбрасывается 

        if (clone != null) // Если у объекта был создан клон, он будет уничтожен, а копия опять получит свойства основного объекта
        {
            gameObject.tag = clone.tag; // Тэг и слой объекта возвращаются к изначальным
            gameObject.layer = clone.layer;
        }

        sr.color = new Color(1, 1, 1, 1); // Цвет объекта также возвращается к изначальному
        Destroy(clone); // Клон уничтожается 
    }
}
