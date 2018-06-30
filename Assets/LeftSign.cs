using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSign : IntersectionRules
{
    public static bool isActive = false;
    public static bool right = false;
    private static string last = "";
    private static IntersectionWrongWay intersection;
    public static void checkIsRight(Transform transform)
    {
        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (transform.name == "ColliderIntersection" && intersection.flag1 && last != "ColliderIntersection4")
            {
                Debug.Log("Krivi smjer");
            }else if (transform.name == "ColliderIntersection" && intersection.flag2 && last != "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
            else if (transform.name == "ColliderIntersection" && intersection.flag3 && last != "ColliderIntersection3")
            {
                Debug.Log("Krivi smjer");
            }
            else if (transform.name == "ColliderIntersection" && intersection.flag4 && last != "ColliderIntersection2")
            {
                Debug.Log("Krivi smjer");
            }
            last = transform.name;
       }
    }
}
