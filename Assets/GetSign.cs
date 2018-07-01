using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSign : MonoBehaviour {

    int number;
    //number = 10000;
    //  int n = number;
    //int n = Convert.ToInt32(Math.Pow(x*y, 2));
    System.Random rnd = new System.Random(0);

    // Use this for initialization
    void Start () {
        number = rnd.Next(1, 3);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
