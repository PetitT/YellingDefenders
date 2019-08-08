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
    private bool hasBeenHitThisFrame;
    private List<AudioClip> trapSounds = new List<AudioClip>();
    private AudioClip wallSound;

    private bool perfectTrapCheck;
    [SerializeField] private GameObject yellowParticles;
    [SerializeField] private GameObject blueParticles;

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
        trapSounds = FindObjectOfType<DataContainer>().caca.sounds.trapSounds;
        wallSound = FindObjectOfType<DataContainer>().caca.sounds.wallSound;
    }

    private void Update()
    {

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (enemyType == 1 || enemyType == 2)
            speed += acceleration;


    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "wall")
        {
            other.GetComponent<WallBehavior>().Health -= damage;
            AudioScript.PlaySound(wallSound);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "perfectTrap" && perfectTrapCheck)
        {
            int trapIndex = other.GetComponent<TrapIndex>().TrappuIndex;
            Debug.Log(trapIndex);
            PlayTrapSound(trapIndex);
            FindObjectOfType<ScoreManager>().ScoreChange(score * 2);
            Instantiate(blueParticles, gameObject.transform.position, blueParticles.transform.rotation);
            Destroy(gameObject);
            hasBeenHitThisFrame = true;
        }
        else if (other.gameObject.tag == "trap" && !perfectTrapCheck)
        {
            int trapIndex = other.GetComponent<TrapIndex>().TrappuIndex;
            Debug.Log(trapIndex);
            PlayTrapSound(trapIndex);
            FindObjectOfType<ScoreManager>().ScoreChange(score);
            Instantiate(yellowParticles, gameObject.transform.position, yellowParticles.transform.rotation);
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

    private void PlayTrapSound(int trapIndex)
    {
        AudioScript.PlaySound(trapSounds[trapIndex]);
    }

}
