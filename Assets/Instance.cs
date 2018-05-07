﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour {
    public Transform prefabRoad, prefabIntersection;
    public Material lijevaTraka, desnaTraka;
    public int x = 5, y = 5, width = 1, height = 1;
    public float additionalWidth = 2.725F;
    //public ArrayList plane = new ArrayList();
    // Use this for initialization
    void Start()
    {
        //promjenimo x i y kako bi dobili traženi broj blokova
        x = x * 2 + 1;
        y = y * 2 + 1;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++) {
                //float size = prefab.GetComponent<Renderer>().bounds.size.x;
                Transform current;
                if (i % 2 != 0)
                {
                    //ovo je za prazni prostor u mreži
                    if (j % 2 != 0 && j != 0) continue;
                    current = Instantiate(prefabRoad, new Vector3(i * height - additionalWidth, 0, (j * width)-additionalWidth), Quaternion.Euler(0, 0, 0));
                }
                else {
                    if(j%2 != 0) current = Instantiate(prefabRoad, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
                    else current = Instantiate(prefabIntersection, new Vector3((i * width), 0, (j * height)), Quaternion.Euler(0, 270, 0));
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
     
    }

    // Update is called once per frame
    void Update () {

	}
}
