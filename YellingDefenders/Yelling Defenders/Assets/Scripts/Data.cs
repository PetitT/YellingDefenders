using System.Collections;
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

        public float enemySpeed;
        public float spawnRate;
        public float spawnOffset;

        public float enemySpeedBuff;
        public float spawnRateBuff;

        public float buffTimer;

        public int wallHealth;
    }

    public Datas data;
    public List<KeyCode> keycodes = new List<KeyCode>();
    public List<int> ennemyDamage = new List<int>();

}
