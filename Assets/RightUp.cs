using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightUp : IntersectionRules {
    public static bool isActive = false;
    private static string last = "";
    private static IntersectionWrongWay intersection;
    public static void checkIsRight(Transform transform)
    {
        intersection = transform.GetComponentInParent<IntersectionWrongWay>();
        isWrongWay(transform);
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
            if (transform.name == "ColliderIntersection2s")
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

}
