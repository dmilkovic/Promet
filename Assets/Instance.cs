using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    public Transform prefabRoad, prefabIntersection, StopSign, LeftUpSign, RightUpSign, LeftSign, RightSign, UpSign, BothWaysSign;
    public static List<Transform> nodes = new List<Transform>();
    public Material lijevaTraka, desnaTraka;
    public int x = 5, y = 5, width = 1, height = 1, cnt = 0, stopTime = 3;
    public float additionalWidth = 2.725F, signX, signZ;
    public Material mat;
    public static StopSign stop;
    private Coroutine c1;
    private Class1 path;
    //  private int[,] graph;
    //public ArrayList plane = new ArrayList();
    // Use this for initialization
    void Start()
    {
        //promjenimo x i y kako bi dobili traženi broj blokova
        x = x * 2 + 1;
        y = y * 2 + 1;
        int j = 0;
        var graph = new Graph();
        stop = (new GameObject("stop")).AddComponent<StopSign>();
        stop.timeLeft = stopTime;

        //threeSideIntersection(0, 0, true);
        //Instantiate(RightUpSign, new Vector3((signZ), 0, 10-(signX)), Quaternion.Euler(270, 180, 0));
        //else if (i == x - 1) threeSideIntersection(i, , false);
        //postavi znakove na rubove
        twoSideIntersection(x, y);
        for (int i = 0; i < x; i++)
        {
            for (j = 0; j < y; j++)
            {
                //float size = prefab.GetComponent<Renderer>().bounds.size.x;
                Transform current;
                if (i % 2 != 0)
                {
                    //ovo je za prazni prostor u mreži
                    if (j % 2 != 0 && j != 0) continue;

                    current = Instantiate(prefabRoad, new Vector3(i * height - additionalWidth, 0, (j * width) - additionalWidth), Quaternion.Euler(0, 0, 0));
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        Transform sign;
                        current = Instantiate(prefabRoad, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
                        //POSTAVLJANJE ZNAKOVA
                        //zadnji u prvom stupcu
                        /* if (j == y - 2 && i == 0)
                         {
                             createSign(LeftSign, i, j, 2);
                             createSign(RightSign, i, j, 1);         
                         }
                         //zadnji u zadnjem stupcu
                         else if (j == y - 2 && i == x - 1)
                         {
                             createSign(LeftSign, i, j, 1);
                             createSign(RightSign, i, j, 4);
                         }
                         else if (i == 0 || i == x - 1)
                         {
                             if (i == 0) threeSideIntersection(i, j, true);
                             else if (i == x - 1) threeSideIntersection(i, j, false);
                         }
                         else
                         {
                             setSign(i, j);
                         }*/
                    }
                    else
                    {
                        current = Instantiate(prefabIntersection, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
                        graph.CreateNode(i + "" + j, cnt, (((x / 2) + 1) * (y / 2 + 1)) - 1);
                        nodes.Add(current);
                        cnt++;
                        //rubni znakovi
                        /*if (i > 0 && i < x - 1)
                        {   //znakovi za prvi redak
                            if (j == 0)
                            {
                                   Instantiate(RightUpSign, new Vector3(i * width + (signZ + (float)0.25), 0, signX), Quaternion.Euler(270, 90, 0));
                                   Instantiate(BothWaysSign, new Vector3(i * width + (signZ - (float)9.8), 0, signX), Quaternion.Euler(270, 0, 0));
                                   Instantiate(LeftUpSign, new Vector3((i * width + signZ - (float)10), 0, -signX), Quaternion.Euler(270, 270, 0));
                            }
                            //znakovi za zadnji redak
                            else if (j == y - 1)
                            {
                                createSign(BothWaysSign, i, j - 1, 1);
                                createSign(LeftUpSign, i, j - 1, 2);
                                createSign(RightUpSign, i, j - 1, 4);
                            }
                        }*/
                    }
                }
                GameObject g = current.gameObject;
                current.name = i + "" + j;
                /*
                 * ako dodaješ znak OBAVEZNOG SMJERA mora ići na sve 4 strane križanja
                 * STOP smije biti s max jedne strane
                 * staviti potrebne znakove na rubna križanja
                 * NA RUBNIM KRIŽANJIMA SU UVIJEK ZNAKOVI ZA SVE SMJEROVE KOJI SU MOGUĆI
                 * OMJER KRIŽANJA I SLOBODNIH KRIŽANJA JE 2:1
                 * 
                 * */
            }
        }
        int number = Convert.ToInt32(Math.Pow(x * y, 2));
        //number = 10000;
        //  int n = number;
        //int n = Convert.ToInt32(Math.Pow(x*y, 2));
        System.Random rnd = new System.Random(0);
        for (int i = 0; i < graph.AllNodes.Count; i++)
        {
            //number = 2+(n /((i+1) * 2)); 
            int numVal = Int32.Parse(graph.AllNodes[i].Name);
            //indexi susjdeda s lijeve i desne strane
            int numDesni = i + (y / 2) + 1;
            int numLijevi = i - (y / 2) - 1;
            //Debug.Log(graph.AllNodes[i].Name + "  " + graph.AllNodes[i].id + " desni: " + numDesni + "  " + graph.AllNodes[i].arcsarr.Count);
            int weigth = 2;
            //prvi stupac(nemaju lijevog susjeda)
            //if (graph.AllNodes[i].id <= (x / 2))
            if (graph.AllNodes[i].id <= (y / 2))
            {
                //ako je na pocetku i nema susjeda ispod
                if (graph.AllNodes[i].id == 0)
                {
                    //weigth = rnd.Next(1,x*y );
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[(y / 2) + 1], weigth);
                    continue;
                }
                //ako je na kraju i nema susjeda iznad
                if (graph.AllNodes[i].id == (y / 2))
                {
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
                    continue;
                }
                //ako je u sredini pa ima susjeda desno, gore i dole
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
            }
            //zadnji stupac(nema desnog susjeda)
            else if (graph.AllNodes[i].id > ((x / 2) * (y / 2) - 1) + x / 2)
            {
                //Debug.Log(graph.AllNodes[i].id + "   " + numDesni);
                //ako je u sredini pa ima susjeda desno, gore i dole
                //prvi
                if (i == ((x / 2) * (y / 2) - 1) + x / 2 + 1)
                {
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    continue;
                }
                //zadnji
                if (i == graph.AllNodes.Count - 1)
                {
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    continue;
                }
                //ostali
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                //Debug.Log(graph.AllNodes[i].Name + "  " + graph.AllNodes[i].id + " lijevi   : " + numLijevi + "  " + graph.AllNodes[i].arcsarr.Count);
            }
            else
            {
                //prvi u tom redu
                if ((graph.AllNodes[i].id % ((y / 2) + 1)) == 0)
                {
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
                    int b = (y / 2) + 1;
                    //Debug.Log("y: " + b + " ID: " + graph.AllNodes[i].id);
                    continue;
                }
                //zadnji u tom redu
                else if (((graph.AllNodes[i].id + 1) % ((y / 2) + 1)) == 0)
                {
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    weigth = rnd.Next(1, number);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
                    int b = (y / 2) + 1;
                    //Debug.Log("y: " + b + " ID: " + graph.AllNodes[i].id);
                    //povećaj random
                    //number = n;
                    continue;
                }
                // Debug.Log(graph.AllNodes[i].Name);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                weigth = rnd.Next(1, number);
                graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
            }
        }

        int[,] adj = graph.CreateAdjMatrix(); // We're going to implement that down below
        Graph.PrintMatrix(adj, graph.AllNodes.Count); // We're going to implement that down belo
        path = new Class1(graph.AllNodes.Count, adj, mat);
        signs(x, y);
    }


    public void signs(int x, int y)
    {

        foreach (GameObject g in path.shortestPath)
        {
            Debug.Log(g.name);
        }
        bool isOnPath = false;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (i % 2 == 0)
                {
                    //float size = prefab.GetComponent<Renderer>().bounds.size.x;
                    if (path.shortestPath.Contains(GameObject.Find(i + "" + (j + 1))))
                    {
                        Debug.Log("Nasao: " + GameObject.Find(i + "" + j) + "   " + path.shortestPath.Count);
                        GameObject currentNode = GameObject.Find(i + "" + j);
                        GameObject next;
                        int broj = path.shortestPath.IndexOf(GameObject.Find(i + "" + j));
                        if (broj + 1 < path.shortestPath.Count)//path.shortestPath[broj + 1] != null)
                        {
                            next = path.shortestPath[broj + 1];
                            if (next.name == (i + 1) + "" + j)
                            {
                                Debug.Log(currentNode.name + "next:" + next.name);
                            }
                            else
                            {
                                Debug.Log(currentNode.name + "next:" + next.name);
                            }
                        }
                        isOnPath = true;
                    }
                    if (j % 2 != 0)
                    {
                        Transform sign;
                        //POSTAVLJANJE ZNAKOVA
                        //zadnji u prvom stupcu
                        if (j == y - 2 && i == 0)
                        {
                            createSign(LeftSign, i, j, 2);
                            createSign(RightSign, i, j, 1);
                        }
                        //zadnji u zadnjem stupcu
                        else if (j == y - 2 && i == x - 1)
                        {
                            createSign(LeftSign, i, j, 1);
                            createSign(RightSign, i, j, 4);
                        }
                        else if (i == 0 || i == x - 1)
                        {
                            if (i == 0) threeSideIntersection(i, j, true);
                            else if (i == x - 1) threeSideIntersection(i, j, false);
                        }
                        else
                        {
                            if (isOnPath)
                            {
                                isOnPath = false;
                                continue;
                            }
                            else
                            {
                                setSign(i, j);
                            }
                        }
                    }
                    else
                    {
                        if (i > 0 && i < x - 1)
                        {   //znakovi za prvi redak
                            if (j == 0)
                            {
                                Instantiate(RightUpSign, new Vector3(i * width + (signZ + (float)0.25), 0, signX), Quaternion.Euler(270, 90, 0));
                                Instantiate(BothWaysSign, new Vector3(i * width + (signZ - (float)9.8), 0, signX), Quaternion.Euler(270, 0, 0));
                                Instantiate(LeftUpSign, new Vector3((i * width + signZ - (float)10), 0, -signX), Quaternion.Euler(270, 270, 0));
                            }
                            //znakovi za zadnji redak
                            else if (j == y - 1)
                            {
                                createSign(BothWaysSign, i, j - 1, 1);
                                createSign(LeftUpSign, i, j - 1, 2);
                                createSign(RightUpSign, i, j - 1, 4);
                            }
                        }
                    }
                }
            }
        }
    }

    System.Random rnd = new System.Random(0);
    public void setSign(int i, int j)
    {
        int number;
        Transform sign;
        number = rnd.Next(1, 5 + 1);
        if (number > 2)
        {
            sign = getSign();
            Debug.Log(sign);
            if (sign == StopSign)
            {
                instantiateOneSign(StopSign, i, j);
            }
            else //if (sign == LeftSign || sign == RightSign || sign == UpSign)
            {
                int n = rnd.Next(1, 2 + 1);
                /*if (n > 1)
                  {*/
                instantiateOneSign(sign, i, j);
                /* }
                 else
                 {


                 }*/
            }
            /* //ispred
             Instantiate(StopSign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(0, 180, 0));
             //desna
             Instantiate(StopSign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 90, 0));
             //iznad
             Instantiate(StopSign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 0, 0));
             //lijeva strana
             Instantiate(StopSign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(0, 270, 0));*/
        }
    }
    public Transform getSign()
    {
        int number;
        number = rnd.Next(1, 3 + 1);
        switch (number)
        {
            case 1: return StopSign;
            case 2:
                number = rnd.Next(1, 3 + 1);
                // return signOneWay(number);
                return signTwoWay(number);
            case 3:
                number = rnd.Next(1, 3 + 1);
                return signOneWay(number);
            default: return null;
        }
    }

    public Transform signOneWay(int n)
    {
        switch (n)
        {
            case 1: return LeftSign;
            case 2: return RightSign;
            case 3: return UpSign;
            default: return null;
        }
    }

    public Transform signTwoWay(int n)
    {
        switch (n)
        {
            case 1: return LeftUpSign;
            case 2: return RightUpSign;
            case 3: return BothWaysSign;
            default: return null;
        }
    }

    public void instantiateOneSign(Transform sign, int i, int j)
    {
        int n = rnd.Next(1, 4 + 1);

        //ispred
        if (n == 1)
        {
            //StopSign i ostali prefabi imaju drukciju rotaciju
            if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(0, 180, 0));
            else createSign(sign, i, j, 1);
            // Instantiate(sign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(270, 180, 0));
        }
        else if (n == 2)
        {
            //desna
            createSign(sign, i, j, 2);
            /*if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 90, 0));
            else Instantiate(sign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 90, 0));*/
        }
        else if (n == 3)
        {
            //iznad
            createSign(sign, i, j, 3);
            /*if (sign == StopSign)  Instantiate(sign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 0, 0));
            else Instantiate(sign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 0, 0));*/
        }
        else
        {
            //lijeva strana
            createSign(sign, i, j, 4);
            /*if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(0, 270, 0));
                else Instantiate(sign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(270, 270, 0));*/
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void threeSideIntersection(int i, int j, bool firstCollumn)
    {
        if (firstCollumn)
        {
            //ispred
            createSign(RightUpSign, i, j, 1);
            //Instantiate(RightUpSign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(270, 180, 0));
            createSign(BothWaysSign, i, j, 2);
            //Instantiate(BothWaysSign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 90, 0));
            //Instantiate(LeftUpSign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 0, 0));
            createSign(LeftUpSign, i, j, 3);
        }
        else
        {
            //Instantiate(LeftUpSign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(270, 180, 0));
            createSign(LeftUpSign, i, j, 1);
            //Instantiate(BothWaysSign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(270, 270, 0));
            createSign(BothWaysSign, i, j, 4);
            //Instantiate(RightUpSign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 0, 0));
            createSign(RightUpSign, i, j, 3);
        }
        //Instantiate(sign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(270, 270, 0));    
    }

    public void twoSideIntersection(int x, int y)
    {
        //Dva znaka za prvo križanje(0,0)
        Instantiate(RightSign, new Vector3((signZ + (float)0.25), 0, signX), Quaternion.Euler(270, 90, 0));
        Instantiate(LeftSign, new Vector3((signZ - (float)9.8), 0, signX), Quaternion.Euler(270, 0, 0));
        //dva znaka za zadnje križanje u prvom retku(0,y)
        //iznad
        Instantiate(RightSign, new Vector3(((x - 1) * width + signZ - (float)9.8), 0, signX), Quaternion.Euler(270, 0, 0));
        //lijevo
        Instantiate(LeftSign, new Vector3(((x - 1) * width + signZ - (float)10), 0, -signX), Quaternion.Euler(270, 270, 0));
    }

    public void createSign(Transform sign, int i, int j, int side)
    {
        // 1 == ispred
        if (side == 1)
        {
            //StopSign i ostali prefabi imaju drukciju rotaciju
            if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(0, 180, 0));
            else Instantiate(sign, new Vector3((i * width + signZ), 0, (j * height + signX)), Quaternion.Euler(270, 180, 0));
        }
        //2 == desno
        else if (side == 2)
        {
            //desna
            if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 90, 0));
            else Instantiate(sign, new Vector3((i * width + signZ + (float)0.25), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 90, 0));
        }

        //3 == iza
        else if (side == 3)
        {
            //iznad
            if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(0, 0, 0));
            else Instantiate(sign, new Vector3((i * width + signZ - (float)9.8), 0, (j * height + 3 * signX)), Quaternion.Euler(270, 0, 0));
        }

        //4 == lijevi
        else
        {
            //lijeva strana
            if (sign == StopSign) Instantiate(sign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(0, 270, 0));
            else Instantiate(sign, new Vector3((i * width + signZ - (float)10.25), 0, (j * height + signX)), Quaternion.Euler(270, 270, 0));
        }
    }
}