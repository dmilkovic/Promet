using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayFirst:MonoBehaviour{
    // Use this for initialization
    public WrongWay x;
    private GameObject parent;
    private WrongWayFirst var;
    void Start()
    {
        x = new WrongWay();
        parent = GameObject.Find(transform.parent.parent.parent.name + "/" + transform.parent.parent.name + "/" + transform.parent.name + "/ColliderFirst");
        var = parent.GetComponent<WrongWayFirst>();
    }
    /*
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(transform.name);
            x.flag1 = true;
           // Debug.Log("Usao u prvi" + "\nflag1: " + x.flag1 + " flag2: "+ x.flag2);
            x.isWrongWay();
        }

       private void OnTriggerExit(Collider other)
        {
            x.flag2 = false;
        }
        */

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(transform.name);
        if(transform.name == "ColliderFirst") var.x.flag1 = true; 
        if(transform.name == "ColliderSecond") var.x.flag2 = true;
        // Debug.Log("Usao u prvi" + "\nflag1: " + x.flag1 + " flag2: "+ x.flag2);
        var.x.isWrongWay();
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.name == "ColliderFirst") var.x.flag2 = false;
        if (transform.name == "ColliderSecond") var.x.flag1 = false;
    }

}
