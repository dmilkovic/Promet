using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayFirst:MonoBehaviour{
    // Use this for initialization
    public WrongWay x;
    void Start()
    {
        x = new WrongWay();
    }

    private void OnTriggerEnter(Collider other)
    {
        x.flag1 = true;
        Debug.Log("Usao u prvi" + "\nflag1: " + x.flag1 + " flag2: "+ x.flag2);
        x.isWrongWay();
    }

   private void OnTriggerExit(Collider other)
    {
        x.flag2 = false;
    }

}
