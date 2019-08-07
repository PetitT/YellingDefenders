using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int scorePerSecond;
    private int scorePerSecondPerSecond = 0;
    private int scoreBoost;

    private void Awake()
    {
        scorePerSecond = FindObjectOfType<DataContainer>().caca.score.scorePerSecond;
        scoreBoost = FindObjectOfType<DataContainer>().caca.score.scoreBoost;
    }

    private void Start()
    {
        StartCoroutine("TimePerSecond");
    }

    public void ScoreChange(int scoreToAdd)
    {

        score += scoreToAdd;
        onScoreChangeEvent.Invoke(score);

    }

    private IEnumerator TimePerSecond()
    {
        yield return new WaitForSeconds(1);
        ScoreChange(scorePerSecond);
        StartCoroutine("TimePerSecond");

    }

    public void ScorePerSecondBoost()
    {

        scorePerSecond += scoreBoost; 

    }

    [System.Serializable]
    public class OnScoreChangeEvent : UnityEvent<int>
    {

    }

    public OnScoreChangeEvent onScoreChangeEvent;

}
