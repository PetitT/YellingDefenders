using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehaviour : MonoBehaviour
{

    private float speed;
    private int damage;

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


    private void Update()
    {

        transform.Translate(Vector3.right * Speed * Time.deltaTime);

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
                Destroy(gameObject);
                break;

        }

    }

}
