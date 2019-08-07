using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private List<Transform> spawns = new List<Transform>();
    [SerializeField] private List<GameObject> ennemys = new List<GameObject>();
    private List<int> enemyDamage = new List<int>();
    private List<int> enemyScore = new List<int>();

    private List<float> ennemySpeed = new List<float>();
    private float spawnRate;
    private float spawnOffset;

    private float spawnRateBuff;
    private float ennemySpeedBuff;
    private float currentennemySpeedBuff;
    private int heal;

    private float buffTimer;

    public UnityEvent DifficultyChange;

    private void Awake()
    {
        enemyDamage = FindObjectOfType<DataContainer>().caca.ennemyDamage;
        enemyScore = FindObjectOfType<DataContainer>().caca.enemyScore;
        ennemySpeed = FindObjectOfType<DataContainer>().caca.data.enemySpeed;
        spawnRate = FindObjectOfType<DataContainer>().caca.data.spawnRate;
        spawnOffset = FindObjectOfType<DataContainer>().caca.data.spawnOffset;
        spawnRateBuff = FindObjectOfType<DataContainer>().caca.data.spawnRateBuff;
        ennemySpeedBuff = FindObjectOfType<DataContainer>().caca.data.enemySpeedBuff;
        buffTimer = FindObjectOfType<DataContainer>().caca.data.buffTimer;
        heal = FindObjectOfType<DataContainer>().caca.data.buffHeal;
    }

    private void Start()
    {
        StartCoroutine("SpawnTimer");
        StartCoroutine("TimePass");
    }

    private IEnumerator SpawnTimer()
    {
        Spawner();
        float actualSpawn = Random.Range(spawnRate - spawnOffset, spawnRate + spawnOffset);
        yield return new WaitForSeconds(actualSpawn);
        StartCoroutine("SpawnTimer");
    }

    private IEnumerator TimePass()
    {

        yield return new WaitForSeconds(buffTimer);



        currentennemySpeedBuff += ennemySpeedBuff;
        spawnRate -= spawnRateBuff;
        FindObjectOfType<WallBehavior>().Health += heal; 
        DifficultyChange.Invoke();
        StartCoroutine("TimePass");

    }

    private void Spawner()
    {
        int numberOfSpawns = Random.Range(1, 3);

        int previousPosition = -1;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            int randomEnnemyIndex = Random.Range(0, ennemys.Count);
            int randomSpawnIndex = Random.Range(0, spawns.Count);
            if (randomSpawnIndex != previousPosition)
            {
                previousPosition = randomSpawnIndex;
                GameObject newEnnemy = Instantiate(ennemys[randomEnnemyIndex], spawns[randomSpawnIndex].position, transform.rotation);
                newEnnemy.GetComponent<EnnemyBehaviour>().Speed = ennemySpeed[randomEnnemyIndex] + ennemySpeedBuff;
                newEnnemy.GetComponent<EnnemyBehaviour>().Damage = enemyDamage[randomEnnemyIndex];
                newEnnemy.GetComponent<EnnemyBehaviour>().Score = enemyScore[randomEnnemyIndex];
                newEnnemy.GetComponent<EnnemyBehaviour>().EnemyType = randomEnnemyIndex;
            }
            else
                i--;
        }



    }

}
