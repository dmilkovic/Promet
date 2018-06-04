using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour {
    public Transform prefabRoad, prefabIntersection;
    public Material lijevaTraka, desnaTraka;
    public int x = 5, y = 5, width = 1, height = 1, cnt = 0;
    public float additionalWidth = 2.725F;
  //  private int[,] graph;
    //public ArrayList plane = new ArrayList();
    // Use this for initialization
    void Start()
    {
        //promjenimo x i y kako bi dobili traženi broj blokova
        x = x * 2 + 1;
        y = y * 2 + 1;
        var graph = new Graph();
        //   graph = new int[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
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
                    if (j % 2 != 0) current = Instantiate(prefabRoad, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
                    else
                    {
                        current = Instantiate(prefabIntersection, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
                        graph.CreateNode(i + "" + j, cnt, (((x/2) + 1) *( y/2 + 1)) - 1);
                        cnt++;
                    }
                }
                GameObject g = current.gameObject;
                current.name = i + "" + j;

                //   Transform[] rotations = current.GetComponentsInChildren<Transform>();
                //   MeshRenderer[] plane = g.GetComponentsInChildren<MeshRenderer>();  
                //plane.Add(current.GetComponent<Plane>());
                /* for (int z = 0; z < plane.Length; z++)
                 {
                     if (plane[z].sharedMaterial == desnaTraka)
                     {
                         //Debug.Log("Green");
                         Debug.Log("Poruka: " + plane[z].name + "Materijal: " + plane[z].sharedMaterial + rotations[z].localRotation.eulerAngles.y);
                         if (Physics.Raycast(current.position, rotations[z].position, 10))
                             print("There is something in front of the object!");
                     }
                     else if (plane[z].sharedMaterial == lijevaTraka) {
                         //Debug.Log("Red");
                         Debug.Log("Poruka: " + plane[z].name + "Materijal: " + plane[z].sharedMaterial + rotations[z].localRotation.eulerAngles.y);
                     }
                     //Debug.Log("Materijal: " + plane[z].sharedMaterial);
                     //Debug.Log("Rotacija: " + current.rotation + " rotations: "+ rotations[z].rotation+ " "+ rotations[z].ToString());
                 }*/

            }
        }
        //MORAS JOS NAPRAVITI ZA PRVI I ZADNJI REDAK
        for (int i = 0; i < graph.AllNodes.Count; i++)
        {
            int numVal = Int32.Parse(graph.AllNodes[i].Name);
            int numDesni = i + (y / 2) + 1;
            int numLijevi = i - (y / 2) - 1;
            //Debug.Log(graph.AllNodes[i].Name + "  " + graph.AllNodes[i].id + " desni: " + numDesni + "  " + graph.AllNodes[i].arcsarr.Count);
            int weigth = 2;
            //prvi stupac(nemaju lijevog susjeda)
            if (graph.AllNodes[i].id <= (x / 2))
            {
                //ako je na pocetku i nema susjeda ispod
                if (graph.AllNodes[i].id == 0)
                {
                    graph.AllNodes[i].AddArc(graph.AllNodes[1], weigth);
                    graph.AllNodes[i].AddArc(graph.AllNodes[(x / 2) + 1], weigth);
                    continue;
                }
                //ako je na kraju i nema susjeda iznad
                if (graph.AllNodes[i].id == (x / 2))
                {
                    graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
                    continue;
                }
                //ako je u sredini pa ima susjeda desno, gore i dole
                graph.AllNodes[i].AddArc(graph.AllNodes[i+1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[numDesni], weigth);
            }
            //zadnji stupac(nema desnog susjeda)
            else if (graph.AllNodes[i].id > ((x / 2) * (y / 2) - 1) +x/2)
            {
                //ako je u sredini pa ima susjeda desno, gore i dole
                //prvi
                if (i == ((x / 2) * (y / 2) - 1) + x / 2 +1)
                {
                    graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    continue;
                }
                //zadnji
                if (i == graph.AllNodes.Count - 1)
                {
                    graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                    graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                    continue;
                }
                //ostali
                graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                //Debug.Log(graph.AllNodes[i].Name + "  " + graph.AllNodes[i].id + " lijevi   : " + numLijevi + "  " + graph.AllNodes[i].arcsarr.Count);
            }
            else
            {
                graph.AllNodes[i].AddArc(graph.AllNodes[i + 1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[i - 1], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
                graph.AllNodes[i].AddArc(graph.AllNodes[numLijevi], weigth);
            }
            
        }

        int?[,] adj = graph.CreateAdjMatrix(); // We're going to implement that down below
        Graph.PrintMatrix(ref adj, graph.AllNodes.Count); // We're going to implement that down belo
    }

    // Update is called once per frame
    void Update () {

	}

}
