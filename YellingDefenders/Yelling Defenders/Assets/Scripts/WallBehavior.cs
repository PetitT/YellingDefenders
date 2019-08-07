using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallBehavior : MonoBehaviour
{

    public int _health;

    public OnLifeChangeEvent onLifeChangeEvent;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            HealthCheck();
            onLifeChangeEvent.Invoke(_health);
        }
    }


    private void Awake()
    {
        _health = FindObjectOfType<DataContainer>().caca.data.wallHealth;
    }

    public UnityEvent Lose;

    [System.Serializable]
    public class OnLifeChangeEvent : UnityEvent <int>
    {

    }

    private void HealthCheck()
    {

        if (Health <= 0)
            Lose.Invoke();
    }
}
