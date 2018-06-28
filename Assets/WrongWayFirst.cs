﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayFirst:MonoBehaviour{
    // Use this for initialization
    public WrongWay x;
    private IntersectionWrongWay intersection;
    private GameObject parent;
    private WrongWayFirst var;
    void Start()
    {
        if (transform.name == "ColliderSecond" || transform.name == "ColliderFirst")
        {
            x = new WrongWay();
            parent = GameObject.Find(transform.parent.parent.parent.name + "/" + transform.parent.parent.name + "/" + transform.parent.name + "/ColliderFirst");
            var = parent.GetComponent<WrongWayFirst>();
        }
    }

  /*  private void Update()
    {
        Debug.Log("Stop active:" + stopSignActive);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(transform.name + " var: " + var.ToString());
        if (transform.name == "ColliderFirst")
        {
            var.x.flag1 = true;
            var.x.isWrongWay();
        }
        if (transform.name == "ColliderSecond")
        {
            var.x.flag2 = true;
            var.x.isWrongWay();
        }

        if (transform.name == "ColliderStop")
        {
            StopSign.stopSignActive = true;
            Debug.Log("Usao u stop");
        }

        if(transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            // intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (StopSign.stopSignActive)
            {
                Debug.Log("yap");
                StopSign.CheckStop(transform);
            }
            else
            {
                Debug.Log("nop");
                IntersectionRules.isWrongWay(transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.name == "ColliderFirst") var.x.flag2 = false;
        if (transform.name == "ColliderSecond") var.x.flag1 = false;
        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (transform.name == "ColliderIntersection")
            {
                intersection.setAllFalse();
                StopSign.stopSignActive = false;
            }
        }
    }

}
/*
public static class Extensions
{
    public static Transform Search(this Transform target, string name)
    {
        Debug.Log("pozvan " + target.childCount);
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; ++i)
        {
            var result = Search(target.GetChild(i), name);

            if (result != null) return result;
        }
        return null;
    }
}*/
