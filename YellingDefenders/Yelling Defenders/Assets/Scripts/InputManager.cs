using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> traps = new List<GameObject>();
    private float yBaseTrapPosition;
    private float yMaxTrapPosition;
    [SerializeField] private List<GameObject> perfectTraps = new List<GameObject>();
    private List<bool> active = new List<bool>();
    private List<bool> canUse = new List<bool>();
    private List<KeyCode> inputs = new List<KeyCode>();
    private float trapDuration;
    private float trapCoolDown;
    private float trapTarget;
    private bool coolDown = true;
    private bool isActive = false;
    public float speed;
    private List<bool> fall = new List<bool>();
    private bool isFalling = false;


    private void Awake()
    {
        inputs = FindObjectOfType<DataContainer>().caca.keycodes;
        trapDuration = FindObjectOfType<DataContainer>().caca.data.trapDuration;
        trapCoolDown = FindObjectOfType<DataContainer>().caca.data.trapCooldown;
        speed = FindObjectOfType<DataContainer>().caca.data.trapSpeed;
        trapTarget = FindObjectOfType<DataContainer>().caca.data.trapTarget;

        for (int i = 0; i < traps.Count; i++)
        {
            fall.Add(isFalling);
        }

        for (int i = 0; i < traps.Count; i++)
        {
            active.Add(isActive);
        }

        for (int i = 0; i < traps.Count; i++)
        {
            canUse.Add(coolDown);
        }

        yBaseTrapPosition = traps[1].transform.position.y;
        yMaxTrapPosition = yBaseTrapPosition + trapTarget;
    }

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


        for (int i = 0; i < traps.Count; i++)
        {

            if(fall[i] == true)
                traps[i].transform.position = Vector3.Lerp(traps[i].transform.position, new Vector3(traps[i].transform.position.x, yBaseTrapPosition, traps[i].transform.position.z), Time.deltaTime * speed);

            if (traps[i].transform.position.y <= yBaseTrapPosition)
                fall[i] = false;

            if(active[i] == true)
            {
                traps[i].transform.position = Vector3.Lerp(traps[i].transform.position, new Vector3(traps[i].transform.position.x, yMaxTrapPosition, traps[i].transform.position.z), Time.deltaTime * speed);
                fall[i] = false;
            }

            if (traps[i].transform.position.y >= yMaxTrapPosition)
                fall[i] = true;

            if (active[i] == false && !(traps[i].transform.position.y <= yBaseTrapPosition))
                fall[i] = true;
        }
              

    }

    private void CheckAndActivate(int inputIndex)
    {
        if (canUse[inputIndex])
            StartCoroutine("ActivateTrap", inputIndex);
    }


    private IEnumerator ActivateTrap(int trapIndex)
    {
        StartCoroutine("CoolDown", trapIndex);
        traps[trapIndex].GetComponent<BoxCollider>().isTrigger = true;
        active[trapIndex] = true;
        perfectTraps[trapIndex].GetComponent<BoxCollider>().isTrigger = true;
        yield return new WaitForSeconds(trapDuration);
        traps[trapIndex].GetComponent<BoxCollider>().isTrigger = false;
        active[trapIndex] = false;
        perfectTraps[trapIndex].GetComponent<BoxCollider>().isTrigger = false;
    }

    private IEnumerator CoolDown(int trapIndex)
    {
        canUse[trapIndex] = false;
        yield return new WaitForSeconds(trapCoolDown);
        canUse[trapIndex] = true;
    }
}
