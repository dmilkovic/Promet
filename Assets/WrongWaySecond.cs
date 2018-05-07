using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWaySecond : WrongWayFirst {

   /* // Use this for initialization
    private GameObject parent;
    private WrongWayFirst var;
    private void Start()
    {
        //  x.flag2 = true;
        //nađemo roditelja i u roditelju objekt koji sadrži skriptu
        //svaki roditelj ima drugo ime i zato možemo razlikovati objekte
        parent = GameObject.Find(transform.parent.parent.parent.name + "/" + transform.parent.parent.name + "/" + transform.parent.name + "/ColliderFirst");
        //parent.GetComponentInChildren<WrongWayFirst>();
       // Debug.Log(transform.name);
        //  GameObject thePlayer = parent.GetComponent(ScriptableObject);
        var = parent.GetComponent<WrongWayFirst>();
    }
    private void OnTriggerEnter(Collider other){
      //  x.flag2 = true;
      //nađemo roditelja i u roditelju objekt koji sadrži skriptu
      //svaki roditelj ima drugo ime i zato možemo razlikovati objekte
        //GameObject parent = GameObject.Find(transform.parent.parent.parent.name + "/" + transform.parent.parent.name + "/" +transform.parent.name + "/ColliderFirst");
        //parent.GetComponentInChildren<WrongWayFirst>();
        //Debug.Log(transform.name);
      //  GameObject thePlayer = parent.GetComponent(ScriptableObject);
      //  WrongWayFirst var = parent.GetComponent<WrongWayFirst>();
        var.x.flag2 = true;
       // Debug.Log("Usao u drugi" + "\nflag1: " + var.x.flag1 + " flag2: " + var.x.flag2 + transform.parent.parent.parent.name );
        var.x.isWrongWay();
    }
    private void OnTriggerExit(Collider other)
    {
        var.x.flag1 = false;
    }
    */
}
