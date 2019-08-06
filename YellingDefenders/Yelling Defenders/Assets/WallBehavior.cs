using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallBehavior : MonoBehaviour
{

    private int _health;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            HealthCheck();
            _health = value;
        }
    }


    public UnityEvent Lose;

    private void HealthCheck()
    {
        if (Health <= 0)
            Lose.Invoke();
    }
}
