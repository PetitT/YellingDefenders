using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{

    private AudioClip beginGame;

    private void Awake()
    {
        beginGame = FindObjectOfType<DataContainer>().caca.sounds.startGame;
    }

    public void buttonStart()
    {
        StartCoroutine("Begin");
    }

    private IEnumerator Begin()
    {
        AudioScript.PlaySound(beginGame);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);

    }

}
