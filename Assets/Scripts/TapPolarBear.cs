using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPolarBear : MonoBehaviour
{
    [SerializeField] private GameObject snowParticlePrefab;
    [SerializeField] private Transform snowParticleTransform;

    private MoneyCounter moneyCounter;
    private new AudioController audio;
    private PolarBearSpawn bearScript;

    void Start()
    {
        audio = GameObject.FindObjectOfType<AudioController>();
        moneyCounter = GameObject.FindObjectOfType<MoneyCounter>();
        bearScript = FindObjectOfType<PolarBearSpawn>();
    }

    /// <summary>
    /// ����� ������ �� ������� - �������� ������ � �������� ������ ���������� �����
    /// </summary>
    private void OnMouseDown()
    {
        audio.TapSound();
        moneyCounter.money += (bearScript.bearValue * bearScript.bearValueMultiplier);
        SnowParticleSpawn();
    }

    /// <summary>
    /// �������� ������ ���������� �����
    /// </summary>
    private void SnowParticleSpawn()
    {
        GameObject snowClone = Instantiate(snowParticlePrefab, snowParticleTransform.position, Quaternion.identity);
        Destroy(snowClone, 1);
    }
}
