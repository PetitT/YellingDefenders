using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deathPannel;

    private void Start()
    {

        deathPannel.SetActive(false);

    }

    public void FadeImage()
    {

        deathPannel.SetActive(true);
        Time.timeScale = 0;

    }

    public void RestartButton()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }

}
