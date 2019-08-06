using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{

    private int speed;
    private int damage;

    public int Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }

    private void Update()
    {

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        switch(collision.tag)
        {

            case "wall":
                collision.GetComponent<WallBehavior>().Health -= damage;
                Destroy(gameObject);
                break;

            case "trap":
                Destroy(gameObject);
                break;

        }

    }

}
