using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Image deathPannel;

    private void Start()
    {

        deathPannel.enabled = false;

    }

    void FadeImage()
    {

        deathPannel.enabled = true;
        Time.timeScale = 0;

    }

    public void RestartButton()
    {

        SceneManager.LoadScene(0);

    }

}
