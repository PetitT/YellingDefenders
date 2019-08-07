﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data", order = 0)]
public class Data : ScriptableObject
{
    [System.Serializable]
    public class Datas
    {
        public float trapDuration;
        public float trapCooldown;

        public List<float> enemySpeed = new List<float>();
        public float enemyAcceleration;
        public float spawnRate;
        public float spawnOffset;

        public float enemySpeedBuff;
        public float spawnRateBuff;

        public float buffTimer;

        public int wallHealth;
    }

    [System.Serializable]
    public class Score
    {
        public int scorePerSecond;
        public int scoreBoost;
    }


    public Score score;
    public Datas data;
    public List<KeyCode> keycodes = new List<KeyCode>();
    public List<int> ennemyDamage = new List<int>();
    public List<int> enemyScore = new List<int>();

}
