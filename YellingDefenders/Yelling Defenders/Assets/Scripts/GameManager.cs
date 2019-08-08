using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathPannel;
    private AudioClip deathClip;

    private void Start()
    {

        deathPannel.SetActive(false);
        deathClip = FindObjectOfType<DataContainer>().caca.sounds.gameOver;

    }

    public void FadeImage()
    {

        deathPannel.SetActive(true);
        AudioScript.PlaySound(deathClip);
        Time.timeScale = 0;

    }

    public void RestartButton()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

}
