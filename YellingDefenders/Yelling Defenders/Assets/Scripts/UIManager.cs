using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    
    [Tooltip("Mon péni est grand XD")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text difficultyText;
    [SerializeField] private Text healthText;
    private int difficultycurve = 1;

    private void Start()
    {
        healthText.text = FindObjectOfType<WallBehavior>().Health.ToString();
        scoreText.text = 0.ToString();
        difficultyText.text = difficultycurve.ToString();
    }

    public void HealthChange(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }

    public void DifficultyChange()
    {

        difficultycurve++;
        difficultyText.text = difficultycurve.ToString();

    }

    public void ScoreChange(int scoreChangeChange)
    {

       scoreText.text = scoreChangeChange.ToString();

    }

}
