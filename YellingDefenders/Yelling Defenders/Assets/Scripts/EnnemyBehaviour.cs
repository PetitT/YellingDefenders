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

    private bool perfectTrapCheck;
    public bool hasBeenHitThisFrame;

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

        if (other.gameObject.tag == "wall")
        {
            other.GetComponent<WallBehavior>().Health -= damage;
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "perfectTrap" && perfectTrapCheck)
        {
            Debug.Log("PerfectTrap");
            FindObjectOfType<ScoreManager>().ScoreChange(score * 2);
            Destroy(gameObject);
            hasBeenHitThisFrame = true;
        }
        else if (other.gameObject.tag == "trap" && !perfectTrapCheck)
        {
            Debug.Log("Trap");
            FindObjectOfType<ScoreManager>().ScoreChange(score);
            Destroy(gameObject);
            hasBeenHitThisFrame = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "perfectTrapCheck")
        {
            perfectTrapCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "perfectTrapCheck")
        {
            perfectTrapCheck = false;
        }
    }


}
