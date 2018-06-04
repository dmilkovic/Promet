using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Graph : MonoBehaviour
{
    public Node Root;
    public List<Node> AllNodes = new List<Node>();

    public Node CreateRoot(string name, int id, int size)
    {
        Root = CreateNode(name, id, size);
        return Root;
    }

    public Node CreateNode(string name,int id, int size)
    {
        var n = new Node(name, id, size);
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

                //var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);
                //Debug.Log(AllNodes.Count +"  " + n1.arcsarr.Count + " j: " + j);
                var arc = n1.arcsarr[j];

                if (arc != null)
                {
                    adj[i, j] = arc.Weigth;
                }
            }
        }
        return adj;
    }

    /*public int[,] getAdjMatrix()
    {
        int[,] adj= new int[AllNodes.Count, AllNodes.Count];

        for (int i = 0; i < AllNodes.Count; i++)
        {
            Node n1 = AllNodes[i];
            for (int j = 0; j < AllNodes.Count; j++)
            {
                adj[i, j] = 0;
                if (n1.Arcs.ElementAtOrDefault(i) != null)
                 {
                    adj[i, j] = n1.Arcs[i].Weigth;
                    Debug.Log("i: " + i + " j: " + j + " " + n1.Arcs[i].Weigth);
                 }
            }
        }
        return adj;
    }*/

    public static void PrintMatrix(ref int?[,] matrix, int Count)
    {
        Debug.Log(String.Format(("       ")));
        String str = "";
        for (int i = 0; i < Count; i++)
        {
            str += (char)('A' + i) + "\t";

        }
        Debug.Log(str);
        //Console.WriteLine();
        Debug.Log(" ");

        for (int i = 0; i < Count; i++)
        {
            String s = " ";
            s += (char)('A' + i);
            Debug.Log(String.Format("{0} | [ ", (char)('A' + i)));
            for (int j = 0; j < Count; j++)
            {
                if (i == j)
                {
                    //Debug.Log(String.Format(" &,"));
                    s += " &,";
                }
                else if (matrix[i, j] > 0)
                {
                    //Debug.Log(String.Format((" .,")));
                    s += matrix[i, j] +", ";
                    
                }
                else
                {
                    //Debug.Log(String.Format(" {0},", matrix[i, j]));
                    s += " .,";
                }

                Debug.Log( "Vrijednost: " + (char)('A' + i) + matrix[i, j]);

            }
            Debug.Log(s);
            Debug.Log(String.Format((" ]\r\n")));

        }
        Debug.Log(String.Format("\r\n"));
    }

    public void Start()
    {
       /* var graph = new Graph();

        var a = graph.CreateRoot("A", 0);
        var b = graph.CreateNode("B", 1);
        var c = graph.CreateNode("C", 2);
        var d = graph.CreateNode("D", 3);
        var e = graph.CreateNode("E", 4);
        var f = graph.CreateNode("F", 5);
        var g = graph.CreateNode("G", 6);
        var h = graph.CreateNode("H", 7);
        var i = graph.CreateNode("I", 8);
        var j = graph.CreateNode("J", 9);
        var k = graph.CreateNode("K", 10);
        var l = graph.CreateNode("L", 11);
        var m = graph.CreateNode("M", 12);
        var n = graph.CreateNode("N", 13);
        var o = graph.CreateNode("O", 14);
        var p = graph.CreateNode("P", 15);

        a.AddArc(b, 1)
         .AddArc(c, 1);

        b.AddArc(e, 1)
         .AddArc(d, 3);

        c.AddArc(f, 1)
         .AddArc(d, 3);

        c.AddArc(f, 1)
         .AddArc(d, 3);

        d.AddArc(h, 8);

        e.AddArc(g, 1)
         .AddArc(h, 3);

        f.AddArc(h, 3)
         .AddArc(i, 1);

        g.AddArc(j, 3)
         .AddArc(l, 1);

        h.AddArc(j, 8)
         .AddArc(k, 8)
         .AddArc(m, 3);

        i.AddArc(k, 3)
         .AddArc(n, 1);

      j.AddArc(o, 3);

        k.AddArc(p, 3);

        l.AddArc(o, 1);

        m.AddArc(o, 1)
         .AddArc(p, 1);

        n.AddArc(p, 1);


        foreach (Node node in graph.AllNodes)
        {
            String s = "";
            foreach (Arc arc in node.Arcs)
            {
                s += "Parent: " + arc.Parent.Name + " Child: " + arc.Child.Name + arc.Weigth;
            }
            Debug.Log(s);
        }

        // o - Already added

        // p - Already added

        int?[,] adj = graph.CreateAdjMatrix(); // We're going to implement that down below

        PrintMatrix(ref adj, graph.AllNodes.Count); // We're going to implement that down belo
        */
    }
}
