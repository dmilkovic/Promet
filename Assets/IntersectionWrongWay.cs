using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionWrongWay : MonoBehaviour {

    private GameObject parent;
    private WrongWayFirst var;

    private void Start()
    {
       // parent = GameObject.Find(transform.parent.parent.parent.name + "/" + transform.parent.parent.name + "/" + transform.parent.name + "/ColliderIntersection1");
        //parent.GetComponentInChildren<WrongWayFirst>();
        // Debug.Log(transform.name);
        //  GameObject thePlayer = parent.GetComponent(ScriptableObject);
       // var = parent.GetComponent<WrongWayFirst>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
