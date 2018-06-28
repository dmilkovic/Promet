using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : IntersectionRules
{
    public static bool stopSignActive = false;
    public StopSign instance;
    public static int timeLeft = 3; //Seconds Overall

    public static void CheckStop(Transform transform)
    {
        Debug.Log("Stop");
        Time.timeScale = 1; //Just making sure that the timeScale is right
        new Timer(timeLeft);
        /*
         Pregledaj po svojim pravilima, zatim pozovi IntersectionIsWrongWay??
         Ali kako će program zvati kada zvati koju klasu?
         Treba napraviti abstraktnu klasnu Intersection koja ima definiranu metodu CheckTrafficSign,
         kad se uđe u križanje i triggera se neki znak zove se prigodna metoda?

        znači uhvatili smo znak, poziva se njegova metoda isWrongWay
        ona ima definirana svoja pravila za prometovanje ali poziva metodu iz isWrongWay iz nasljeđene klase?
        ako je bio npr stop na njegov collider enter se zove 
         */
    }

    public class Timer : MonoBehaviour
    {
        private int timeLeft;
        public Timer(int time)
        {
            this.timeLeft = time;
            StartCoroutine(LoseTime());
            Debug.Log("Time:" + timeLeft);
        }

        //Simple Coroutine
        IEnumerator LoseTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
        }
    }


}
