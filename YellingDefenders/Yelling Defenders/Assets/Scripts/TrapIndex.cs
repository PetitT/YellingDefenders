using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapIndex : MonoBehaviour {

    [SerializeField] private int trapIndex;

    public int TrappuIndex
    {
        get
        {
            return trapIndex;
        }

        set
        {
            trapIndex = value;
        }
    }
}
