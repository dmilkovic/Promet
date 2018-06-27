using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionRules : MonoBehaviour {

    public static void isWrongWay(Transform transform)
    {
        IntersectionWrongWay intersection = transform.GetComponentInParent<IntersectionWrongWay>();
        if (intersection.flag1)
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
        }
    }

}
