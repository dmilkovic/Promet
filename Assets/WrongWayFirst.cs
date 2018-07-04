using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongWayFirst:MonoBehaviour{
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
            Instance.stop.CheckStop(transform);
            //Timer(3);
        }

        if (transform.name == "ColliderUp")
        {
            UP.isActive = true;
            Debug.Log("Usao u UP");
        }

        if (transform.name == "ColliderLeft&Up")
        {
            LeftUp.isActive = true;
            Debug.Log("Usao u Left&UP");
        }

        if (transform.name == "ColliderLeft")
        {
            LeftSign.isActive = true;
            Debug.Log("Left");
        }

        if (transform.name == "ColliderRight")
        {
            RightSign.isActive = true;
            Debug.Log("Right");
        }

        if (transform.name == "ColliderRight&Up")
        {
            RightUp.isActive = true;
            Debug.Log("RightUP");
        }

        if (transform.name == "ColliderBoth")
        {
            LeftRight.isActive = true;
            Debug.Log("Left & Right");
        }

        if (transform.name == "ColliderWrongWay")
        {  
            Debug.Log("Krivi smjer!");
        }

        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            // intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (UP.isActive)
            {
                UP.check(transform);
            }
            else if (LeftUp.isActive)
            {
                LeftUp.isWrongWay(transform);
            }
            else if (LeftSign.isActive)
            {
                LeftSign.isWrongWay(transform);
            }
            else if (RightSign.isActive)
            {
                RightSign.checkIsRight(transform);
            }
            else if (RightUp.isActive)
            {
                RightUp.checkIsRight(transform);
            }else if(LeftRight.isActive)
            {
                LeftRight.isWrongWay(transform);
            }
            else
            {
                //Debug.Log("nop");
                IntersectionRules.isWrongWay(transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (transform.name == "ColliderFirst") var.x.flag2 = false;

        if (transform.name == "ColliderSecond") var.x.flag1 = false;
        //ako je lijevi znak aktivan primjeni njegova pravila
        if (LeftSign.isActive)
        {
            LeftSign.checkIsRight(transform);
        }
        if (LeftUp.isActive)
        {
            LeftUp.checkIsRight(transform);
        }
        if (LeftRight.isActive)
        {
            LeftRight.checkIsRight(transform);
        }
        //ako je desni znak aktivan primjeni njegova pravila
        /* if (RightSign.isActive)
         {
             LeftSign.checkIsRight(transform);
         }*/

        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            
            if (transform.name == "ColliderIntersection")
            {
                intersection.setAllFalse();
                UP.isActive = false;
                LeftSign.isActive = false;
                RightSign.isActive = false;
                RightUp.isActive = false;
                LeftUp.isActive = false;
                LeftRight.isActive = false;
            }
        }

        if (transform.name == "ColliderStop")
        {
            if (!StopSign.timerDone)
            {
                Debug.Log("NISI STAO NA STOP");
            }
            StopSign.stopSignActive = false;
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
