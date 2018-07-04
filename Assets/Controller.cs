using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float speed = 5f;
    public float rotate = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.Rotate(0f, speed * Input.GetAxis("Horizontal") * rotate  * Time.deltaTime, 0f);
	}
}
