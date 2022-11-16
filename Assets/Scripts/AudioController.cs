using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip iceKingSound;
    [SerializeField] private AudioClip breakIceSound;
    [SerializeField] private AudioClip mergeSound;
    [SerializeField] private AudioClip buildStationSound;
    [SerializeField] private AudioClip stationReceiveSound;
    [SerializeField] private AudioClip tapSound;
    [SerializeField] private AudioClip penguinSound;

    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ������������ ����� ������������� ����
    /// </summary>
    public void BreakIceSound()
    {
        audio.PlayOneShot(breakIceSound);
    }

    /// <summary>
    /// ������������ ����� �������
    /// </summary>
    public void MergeSound()
    {
        audio.PlayOneShot(mergeSound);
    }

    /// <summary>
    /// ������������ ����� �������
    /// </summary>
    public void BuildStationSound()
    {
        audio.PlayOneShot(buildStationSound);
    }

    /// <summary>
    /// ������������ ����� ��������� �������������
    /// </summary>
    public void StationReceiveSound()
    {
        audio.PlayOneShot(stationReceiveSound);
    }

    /// <summary>
    /// ������������ ����� ���� 
    /// </summary>
    public void TapSound()
    {
        audio.PlayOneShot(tapSound);
    }

    /// <summary>
    /// ������������ ����� �������� ��������
    /// </summary>
    public void PenguinSound()
    {
        audio.PlayOneShot(penguinSound);
    }
}
