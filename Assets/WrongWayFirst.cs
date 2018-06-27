using System.Collections;
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

        if(transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
           // intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            IntersectionRules.isWrongWay(transform);
           /* if (intersection.flag1)
            {
                if (transform.name == "ColliderIntersection3")
                {
                    Debug.Log("Krivi smjer");
                }
            }
            if (intersection.flag2)
            {
                if (transform.name == "ColliderIntersection1")
                {
                    Debug.Log("Krivi smjer");
                }
            }
            if (intersection.flag3)
            {
                if (transform.name == "ColliderIntersection4")
                {
                    Debug.Log("Krivi smjer");
                }
            }
            if (intersection.flag4)
            {
                if (transform.name == "ColliderIntersection2")
                {
                    Debug.Log("Krivi smjer");
                }
            }
            if (!intersection.flag1 && !intersection.flag2 && !intersection.flag3 && !intersection.flag4)
            {
                if (transform.name == "ColliderIntersection1")
                {
                    Debug.Log("Usao uz " + transform.name);
                    intersection.flag1 = true;

                    //   transform.root.Search("ColliderIntersection2").GetComponent<BoxCollider>().enabled = false;
                    //   transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
                    // transform.root.Search("ColliderIntersection2").GetComponent<BoxCollider>().enabled = false;
                    //  transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
                    // BoxCollider col = GameObject.Find(transform.parent.parent.name + "/" + transform.parent.name + "/ColliderIntersection3").GetComponent<BoxCollider>();
                    //  GameObject root = transform.root.gameObject;
                    // BoxCollider col = transform.Find("ColliderIntersection3").GetComponent<BoxCollider>();
                }
                else if (transform.name == "ColliderIntersection2")
                {
                    Debug.Log("Usao uz " + transform.name);
                    intersection.flag2 = true;
                }
                else if (transform.name == "ColliderIntersection3")
                {
                    Debug.Log("Usao uz " + transform.name);
                    intersection.flag3 = true;
                    //  transform.root.Search("ColliderIntersection1").GetComponent<BoxCollider>().enabled = false;
                    //  transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
                }
                else if (transform.name == "ColliderIntersection4")
                {
                    Debug.Log("Usao uz " + transform.name);
                    intersection.flag4 = true;
                }
            }*/
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
