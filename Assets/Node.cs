using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public string Name;
    public int id;
    public List<Arc> Arcs = new List<Arc>();
    public List<Arc> arcsarr = new List<Arc>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public Node(string name, int id, int size )
    {
        Name = name;
        this.id = id;
        for (int i = 0; i <= size; i++)
        {
            arcsarr.Add(null);
        }
    }

    /// <summary>
    /// Create a new arc, connecting this Node to the Nod passed in the parameter
    /// Also, it creates the inversed node in the passed node
    /// </summary>
    public Node AddArc(Node child, int w)
    {
        /*  Arcs.Add(new Arc
          {
              Parent = this,
              Child = child,
              Weigth = w
          });*/
        //ako je node već dodan u susjede
        if (arcsarr[child.id] != null) return this;

        //ako nije dodan susjed
        arcsarr[child.id] = new Arc
        {
            Parent = this,
            Child = child,
            Weigth = w
        };
        //  Debug.Log("Sad sam na" + "Parent: "+ this.Name + " Child: " + child.Name);
        /*if (!child.Arcs.Exists(a => a.Parent == child && a.Child == this))
        {
            child.AddArc(this, w);
        //    Debug.Log("dodaje se"  + " Parent:" + child.Name + " Child:" + this.Name);
        }*/
        if(child.arcsarr[this.id] == null)
        {
            child.AddArc(this, w);
        }
        return this;
    }
}
