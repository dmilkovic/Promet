using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Graph {

    public Node Root;
    public List<Node> AllNodes = new List<Node>();

    public Node CreateRoot(string name)
    {
        Root = CreateNode(name);
        return Root;
    }

    public Node CreateNode(string name)
    {
        var n = new Node(name);
        AllNodes.Add(n);
        return n;
    }

    public int?[,] CreateAdjMatrix()
    {
        int?[,] adj = new int?[AllNodes.Count, AllNodes.Count];

        for (int i = 0; i < AllNodes.Count; i++)
        {
            Node n1 = AllNodes[i];

            for (int j = 0; j < AllNodes.Count; j++)
            {
                Node n2 = AllNodes[j];

                var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);

                if (arc != null)
                {
                    adj[i, j] = arc.Weigth;
                }
            }
        }
        return adj;
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
