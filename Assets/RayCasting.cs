using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(MyFunction());
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            theDistance = hit.distance;
            float playerRotationY = transform.rotation.eulerAngles.y;
            if (playerRotationY <= 90 || playerRotationY >= 270) {

            }
            //Debug.Log(theDistance + " " + hit.collider.gameObject.name);
            //mozda treba usporediti sa rotacijom svijeta tj "hit.collider.transform.rotation.eulerAngles.y"
            /*if (transform.rotation.eulerAngles.y >= hit.collider.transform.localRotation.eulerAngles.y + 90 || transform.rotation.eulerAngles.y <= hit.collider.transform.localRotation.eulerAngles.y - 90)
            {
                Debug.Log("Krivi smjer!");
            }*/

            if (transform.rotation.eulerAngles.y >= hit.collider.transform.rotation.eulerAngles.y + 90 || transform.rotation.eulerAngles.y <= hit.collider.transform.rotation.eulerAngles.y - 90)
            {
                Debug.Log("Krivi smjer!");
            }

           // Debug.Log("Nas kut:" + transform.rotation.eulerAngles.y + " Kut objekta: " + hit.collider.transform.localRotation.eulerAngles.y + "Kut world:" + hit.collider.transform.rotation.eulerAngles.y);
        }
    }

   /* IEnumerator MyFunction() {
        RaycastHit hit;
        float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            theDistance = hit.distance;
            Debug.Log(theDistance + " " + hit.collider.gameObject.name);
            if (transform.rotation.eulerAngles.y >= hit.collider.transform.localRotation.eulerAngles.y + 45 || transform.rotation.eulerAngles.y <= hit.collider.transform.localRotation.eulerAngles.y - 45)
            {
                Debug.Log("Krivi smjer!");
            }
            Debug.Log("Nas kut:" + transform.rotation.eulerAngles.y + " Kut objekta: " + hit.collider.transform.localRotation.eulerAngles.y + "Kut world:" + hit.collider.transform.rotation.eulerAngles.y);
        }
        yield return new WaitForSeconds(2);
    }*/

}
