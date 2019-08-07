using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyBehaviour : MonoBehaviour
{

    private float speed;
    private int damage;
    private int score;
    private int enemyType;
    private float acceleration;

    public int EnemyType
    {
        get { return enemyType; }
        set { enemyType = value; }
    }


    public int Score
    {
        get { return score; }
        set { score = value; }
    }


    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    private void Awake()
    {
        acceleration = FindObjectOfType<DataContainer>().caca.data.enemyAcceleration;
    }

    private void Update()
    {

        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (enemyType == 1)
            speed += acceleration;


    }

    private void OnTriggerStay(Collider other)
    {


        switch (other.gameObject.tag)
        {

            case "wall":
                other.GetComponent<WallBehavior>().Health -= damage;
                Destroy(gameObject);
                break;

            case "trap":
                FindObjectOfType<ScoreManager>().ScoreChange(score);
                Destroy(gameObject);
                break;

        }

    }


}
