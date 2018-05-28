using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public string Name;
    public List<WrongWay> Arcs = new List<WrongWay>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public Node(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Create a new arc, connecting this Node to the Nod passed in the parameter
    /// Also, it creates the inversed node in the passed node
    /// </summary>
    public Node AddArc(Node child, int w)
    {
        Arcs.Add(new WrongWay
        {
            Parent = this,
            Child = child,
            Weigth = w
        });

        if (!child.Arcs.Exists(a => a.Parent == child && a.Child == this))
        {
            child.AddArc(this, w);
        }

        return this;
    }
}
