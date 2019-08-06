using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private List<Transform> spawns = new List<Transform>();
    [SerializeField] private List<GameObject> ennemys = new List<GameObject>();
    private List<int> enemyDamage = new List<int>();

    private int ennemySpeed;
    private int spawnRate;

    private void Start()
    {
        StartCoroutine("SpawnTimer");
    }

    private IEnumerator SpawnTimer()
    {
        Spawner();
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine("SpawnTimer");
    }

    private void Spawner()
    {
        int randomSpawnIndex = Random.Range(0, spawns.Count);
        int randomEnnemyIndex = Random.Range(0, ennemys.Count);
        GameObject newEnnemy = Instantiate(ennemys[randomEnnemyIndex], spawns[randomSpawnIndex].position, transform.rotation);
        newEnnemy.GetComponent<EnnemyBehaviour>().Speed = ennemySpeed;
        newEnnemy.GetComponent<EnnemyBehaviour>().Damage = enemyDamage[randomEnnemyIndex];
    }

}
