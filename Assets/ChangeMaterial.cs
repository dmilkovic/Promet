using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {

    // Use this for initialization
    public Material mat;
	void Start () {
        GetComponent<Renderer>().material = mat;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
