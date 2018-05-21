using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterSectionCollider1 : MonoBehaviour
{
    private IntersectionWrongWay var;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var = transform.GetComponentInParent<IntersectionWrongWay>();
        if (var.flag1)
        {
            if (transform.name == "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (var.flag2)
        {
            if (transform.name == "ColliderIntersection1")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (var.flag3)
        {
            if (transform.name == "ColliderIntersection4")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (var.flag4)
        {
            if (transform.name == "ColliderIntersection2")
            {
                Debug.Log("Krivi smjer");
            }
        }
        //Debug.Log("IntesectionCollider1" + var.flag2);
        /*  if (transform.name == "ColliderIntersection1")
          {
              var.flag1 = true;
              Debug.Log("IntesectionCollider1" + var.flag1);
          }*/

        if (!var.flag1 && !var.flag2 && !var.flag3 && !var.flag4)
        {
            if (transform.name == "ColliderIntersection1")
            {
                Debug.Log("Usao uz " + transform.name);
                var.flag1 = true;
                
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
                var.flag2 = true;
            }
            else if (transform.name == "ColliderIntersection3")
            {
                Debug.Log("Usao uz " + transform.name);
                var.flag3 = true;
                //  transform.root.Search("ColliderIntersection1").GetComponent<BoxCollider>().enabled = false;
                //  transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
            }
            else if (transform.name == "ColliderIntersection4")
            {
                Debug.Log("Usao uz " + transform.name);
                var.flag4 = true;
            }

            // Debug.Log(other.name);
        }
        /*else
        {
            Debug.Log("Usao u " + transform.name);
            if (var.flag1)
            {
                if (transform.name == "ColliderIntersection3")
                {
                    Debug.Log("Krivi smjer");
                }
                // BoxCollider col = GameObject.Find(transform.parent.parent.name + "/" + transform.parent.name + "/ColliderIntersection3").GetComponent<BoxCollider>();
                //  GameObject root = transform.root.gameObject;
                // BoxCollider col = transform.Find("ColliderIntersection3").GetComponent<BoxCollider>();
                Debug.Log(other.name);
            }
            else if (var.flag2)
            {
            }
            else if (var.flag3)
            {
                Debug.Log("je f3 true" + transform.name);
                if (transform.name == "ColliderIntersection1")
                {
                    Debug.Log("Krivi smjer");
                }
            }
            else if (var.flag4)
            {
            }*/

            Debug.Log("var: " + var);
        //}
        Debug.Log("F1: " + var.flag1 + "F2: " + var.flag2 + "F3: " + var.flag3 + "F4: " + var.flag4);
    }

    private void OnTriggerExit(Collider other)
    {
        var = transform.GetComponentInParent<IntersectionWrongWay>();
        if (transform.name == "ColliderIntersection")
        {
            var.setAllFalse();
        }
    }
}
