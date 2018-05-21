using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionWrongWay : MonoBehaviour {

    public bool flag1;
    public bool flag2;
    public bool flag3, flag4;
    public int id;
    //public IntersectionWrongWay x;
  //  public IntersectionWrongWay var;
    public static List <IntersectionWrongWay> colliders = new List <IntersectionWrongWay>();
    public static int cnt = 0;

    public IntersectionWrongWay()
    {
        this.flag1 = false;
        this.flag2 = false;
        this.flag3 = false;
        this.flag4 = false;
        this.id = cnt;
        cnt++;
        colliders.Add(this);
    }

    public void isWrongWay1()
    {
        if (this.flag2 && !this.flag1)
        {
            Debug.Log("Krivi smjer!");
        }
    }

    public void setAllFalse()
    {
        this.flag1 = false;
        this.flag2 = false;
        this.flag3 = false;
        this.flag4 = false;
    }

    private void Start()
    {
        
      //  var = transform.root.Search("Plane").GetComponent<IntersectionWrongWay>();
        //var = transform.root.Search("ColliderIntersection2").GetComponent<IntersectionWrongWay>();
    }
   /* public static void trigger()
    {
        if(!this.flag1 && !this.flag2 && !this.flag3 && !this.flag4)
        {
            if (transform.name == "ColliderIntersection1")
            {
                Debug.Log("Usao u " + transform.name);
                this.flag1 = true;
                transform.root.Search("ColliderIntersection2").GetComponent<BoxCollider>().enabled = false;
                transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
                // BoxCollider col = GameObject.Find(transform.parent.parent.name + "/" + transform.parent.name + "/ColliderIntersection3").GetComponent<BoxCollider>();
                //  GameObject root = transform.root.gameObject;
                // BoxCollider col = transform.Find("ColliderIntersection3").GetComponent<BoxCollider>();
            }
           // Debug.Log(other.name);
        }else if (flag1) {
            Debug.Log("Usao u " + transform.name);
            transform.root.Search("ColliderIntersection2").GetComponent<BoxCollider>().enabled = false;
            transform.root.Search("ColliderIntersection4").GetComponent<BoxCollider>().enabled = false;
            if(transform.name == "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
            // BoxCollider col = GameObject.Find(transform.parent.parent.name + "/" + transform.parent.name + "/ColliderIntersection3").GetComponent<BoxCollider>();
            //  GameObject root = transform.root.gameObject;
            // BoxCollider col = transform.Find("ColliderIntersection3").GetComponent<BoxCollider>();
            Debug.Log(other.name);
            }

    }*/

    // Update is called once per frame
    void Update () {
		
	}
}
