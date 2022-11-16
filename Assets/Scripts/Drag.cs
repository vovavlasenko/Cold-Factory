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

    private void OnMouseDown() // ���� �� ������� ����� ���� ������, ������� �� ������ ������ ���� ������ � ��������������
    {
        if (itemSpawnerScript.canBeDragged == true) // ���� �������������� ������� �������� 
        {
            isDragging = true; // ���� ������ ��� ��������������

            if (gameObject.tag != "Penguin")
            {
                clone = Instantiate(gameObject, transform.position, Quaternion.identity); // ������� ����, ��� � ����� �������������
                gameObject.layer = 10; 
                gameObject.tag = "Copy";// ��� ������ ���������� ������, ��������� � ������, ������� ����� ���������� �������� �� ���������
                sr.color = new Color(0.7f, 0.4f, 0.4f, 0.7f); // ����� ���������� �� ����� ����� ��������
            }
        }
    }

    private void OnMouseUp() // ��� ���������� �������
    {
        DragAborted(); // ��������� ��������������
    }

    void Update()
    {
        if (isDragging == true) // �������������� ������� (���� ��� �������), ��� ����� (���� ��� ������ ��� �������� �������� �������)
        {
            screenPos = Input.mousePosition;
            worldPos = Camera.main.ScreenToWorldPoint(screenPos);          

            if (clone != null)
                clone.transform.localPosition = new Vector3(worldPos.x, worldPos.y, 0);

            else
                this.gameObject.transform.localPosition = new Vector3(worldPos.x, worldPos.y, 0); 
        }

        if (clone != null && clone.transform.position.x > gameObject.transform.position.x + 1) // ������������� ����� ������ �����
        {
            DragAborted(); // � ��������� ������ ��������� ��������������

        }
    }

    private void DragAborted()
    {
        isDragging = false; // �������������� ������������ 

        if (clone != null) // ���� � ������� ��� ������ ����, �� ����� ���������, � ����� ����� ������� �������� ��������� �������
        {
            gameObject.tag = clone.tag; // ��� � ���� ������� ������������ � �����������
            gameObject.layer = clone.layer;
        }

        sr.color = new Color(1, 1, 1, 1); // ���� ������� ����� ������������ � ������������
        Destroy(clone); // ���� ������������ 
    }
}
