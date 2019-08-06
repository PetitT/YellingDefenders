﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> traps = new List<GameObject>();
    private List<bool> canUse = new List<bool>();
    private List<KeyCode> inputs = new List<KeyCode>();
    private int trapDuration;
    private int trapCoolDown;
    string truc;

    private void Update()
    {
        if (Input.GetKeyDown(inputs[0]))
            CheckAndActivate(0);

        if (Input.GetKeyDown(inputs[1]))
            CheckAndActivate(1);

        if (Input.GetKeyDown(inputs[2]))
            CheckAndActivate(2);

        if (Input.GetKeyDown(inputs[3]))
            CheckAndActivate(3);

        if (Input.GetKeyDown(inputs[4]))
            CheckAndActivate(4);
    }

    private void CheckAndActivate(int inputIndex)
    {
        if (canUse[inputIndex])
            StartCoroutine("ActivateTtrap", inputIndex);
    }


    private IEnumerator ActivateTrap(int trapIndex)
    {
        StartCoroutine("CoolDown", trapIndex);
        traps[trapIndex].GetComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(trapDuration);
        traps[trapIndex].GetComponent<BoxCollider>().isTrigger = false;
    }

    private IEnumerator CoolDown(int trapIndex)
    {
        canUse[trapIndex] = false;
        yield return new WaitForSeconds(trapCoolDown);
        canUse[trapIndex] = true;
    }
}
