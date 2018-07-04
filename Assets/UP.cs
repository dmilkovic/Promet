using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP : IntersectionRules {
    public static bool isActive = false;
    private static string last = "";
    private static IntersectionWrongWay intersection;
    public static void check(Transform transform)
    {
        isWrongWay(transform);
        intersection = transform.GetComponentInParent<IntersectionWrongWay>();
        if (intersection.flag1)
        {
            if (transform.name == "ColliderIntersection4")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (intersection.flag2)
        {
            if (transform.name == "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (intersection.flag3)
        {
            if (transform.name == "ColliderIntersection2")
            {
                Debug.Log("Krivi smjer");
            }
        }
        if (intersection.flag4)
        {
            if (transform.name == "ColliderIntersection1")
            {
                Debug.Log("Krivi smjer");
            }
        }
    }

    public static void checkIsRight(Transform transform)
    {
        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (transform.name == "ColliderIntersection" && intersection.flag1 && last != "ColliderIntersection2")
            {
                Debug.Log("Krivi smjer");
            }
            else if (transform.name == "ColliderIntersection" && intersection.flag2 && last != "ColliderIntersection4")
            {
                Debug.Log("Krivi smjer");
            }
            else if (transform.name == "ColliderIntersection" && intersection.flag3 && last != "ColliderIntersection1")
            {
                Debug.Log("Krivi smjer");
            }
            else if (transform.name == "ColliderIntersection" && intersection.flag4 && last != "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
            last = transform.name;
        }
    }
}
