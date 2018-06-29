using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSign : IntersectionRules
{
    public static bool stopSignActive = false, timerDone;
    public StopSign instance;
    private Coroutine c1;
    public int timeLeft = 3; //Seconds Overall
    public StopSign(int time)
    {
        timeLeft = time;
    }

    public void CheckStop(Transform transform)
    {
        Debug.Log("Stop");
        Time.timeScale = 1; //Just making sure that the timeScale is right
        Timer(timeLeft);
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
    //STOP ZNAK
    ///private Coroutine c1;
    private void Update()
    {
        if (timeLeft == 0)
        {
            StopCoroutine(c1);
        }
        if(timerDone) StopCoroutine(c1);
    }

    public void Timer(int time)
    {
        c1 = StartCoroutine(LoseTime(time));
    }

    //odbrojava vrijeme
    IEnumerator LoseTime(int time)
    {
        timerDone = false;
        Debug.Log("Time:" + timeLeft);
        yield return new WaitForSeconds(time);
        timerDone = true;
        Debug.Log("Gotov!  ");
    }

}
