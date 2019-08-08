using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelleDelphine : MonoBehaviour {

    [SerializeField] private float cameraSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.LookAt(gameObject.transform);
        Camera.main.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
	}
}
