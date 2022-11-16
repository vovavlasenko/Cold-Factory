using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private new AudioSource audio;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject pausePanel;

    /// <summary>
    /// ����� �� ����������
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// ����� � ������� ����
    /// </summary>
    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(DelayedStart(0));
        StartCoroutine(AudioFade(audio, 1f));
    }

    /// <summary>
    /// ����� ����
    /// </summary>
    public void StartGame()
    {       
        StartCoroutine(DelayedStart(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(AudioFade(audio, 1f));
    }

    /// <summary>
    /// ���������� �����, ����� �����
    /// </summary>
    /// <param name="sceneIndex"></param>
    /// <returns></returns>
    IEnumerator DelayedStart(int sceneIndex)
    {
        anim.SetTrigger("startFade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    /// <param name="audioSource"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    IEnumerator AudioFade(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    public void PauseOn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// ���������� �����
    /// </summary>
    public void PauseOff()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
