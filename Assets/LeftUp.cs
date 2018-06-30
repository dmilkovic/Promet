using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftUp : IntersectionRules {
    public static bool isActive = false;
    private static string last = "";
    private static IntersectionWrongWay intersection;

    //ako izađe iz desnog trigerra onda je prekršio pravilo
    public static void checkIsRight(Transform transform)
    {
        if (transform.GetComponentInParent<IntersectionWrongWay>() != null)
        {
            intersection = transform.GetComponentInParent<IntersectionWrongWay>();
            if (intersection.flag1)
            {
                if (transform.name == "ColliderIntersection1")
                {
                    Debug.Log("Krivi smjer");
                }
            }

            if (intersection.flag2)
            {
                if (transform.name == "ColliderIntersection2")
                {
                    Debug.Log("Krivi smjer");
                }
            }

            if (intersection.flag3)
            {
                if (transform.name == "ColliderIntersection3")
                {
                    Debug.Log("Krivi smjer");
                }
            }

            if (intersection.flag4)
            {
                if (transform.name == "ColliderIntersection4")
                {
                    Debug.Log("Krivi smjer");
                }
            }
        }
    }

    public static void check(Transform transform)
    {
        isWrongWay(transform);
        IntersectionWrongWay intersection = transform.GetComponentInParent<IntersectionWrongWay>();
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
}
