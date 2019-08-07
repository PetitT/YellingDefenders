using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{

    private string[] cheat;
    private int cheatIndex = 0;
    private bool hasCheated = false;

    [SerializeField] private List<GameObject> tentacles = new List<GameObject>();
    [SerializeField] private List<GameObject> traps = new List<GameObject>();

    private void Start()
    {
        cheat = new string[] { "t", "h", "i", "b", "a", "u", "t" };
    }

    private void Update()
    {
        if (Input.anyKeyDown && !hasCheated)
            if (Input.GetKeyDown(cheat[cheatIndex]))
            {
                cheatIndex++;
                if (cheatIndex == cheat.Length)
                {
                    for (int i = 0; i < tentacles.Count; i++)
                    {
                        tentacles[i].SetActive(true);
                    }
                    for (int i = 0; i < traps.Count; i++)
                    {
                        traps[i].SetActive(false);
                    }
                    cheatIndex = 0;
                    hasCheated = true;
                }
            }
            else
                cheatIndex = 0;
    }

}
