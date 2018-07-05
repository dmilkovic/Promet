// A C++ program for Dijkstra's single source shortest path algorithm.
// The program is for adjacency matrix representation of the graph
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Number of vertices in the graph


// A utility function to find the vertex with minimum distance value, from
// the set of vertices not yet included in shortest path tree
public class ShortestPath : MonoBehaviour{
    private int V = 9;
    private static int NO_PARENT = -1;
    public Material mat;
    public List<GameObject> shortestPath = new List<GameObject>();
    //private List <int> nodePath = new List<int>();
    private int[,] graph;

    public ShortestPath(int size, int[,] graph)
    {
        this.V = size;
        this.graph = graph;
        dijkstra(graph, 0);
        // Start();
    }

    public ShortestPath(int size, int[,] graph, Material m)
    {
        this.V = size;
        this.graph = graph;
        dijkstra(graph, 0);
        this.mat = m;
       // Start();
    }

    private void dijkstra(int[,] adjacencyMatrix,  int startVertex)
    {
        int nVertices = adjacencyMatrix.GetUpperBound(1);

        // shortestDistances[i] will hold the
        // shortest distance from src to i
        int[] shortestDistances = new int[nVertices];

        // added[i] will true if vertex i is
        // included / in shortest path tree
        // or shortest distance from src to 
        // i is finalized
        bool[] added = new bool[nVertices];

        // Initialize all distances as 
        // INFINITE and added[] as false
        for (int vertexIndex = 0; vertexIndex < nVertices;vertexIndex++)
        {
            shortestDistances[vertexIndex] = int.MaxValue;
            added[vertexIndex] = false;
        }

        // Distance of source vertex from
        // itself is always 0
        shortestDistances[startVertex] = 0;

        // Parent array to store shortest
        // path tree
        int[] parents = new int[nVertices];

        // The starting vertex does not 
        // have a parent
        parents[startVertex] = NO_PARENT;

        // Find shortest path for all 
        // vertices
        for (int i = 1; i < nVertices; i++)
        {
            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. nearestVertex is 
            // always equal to startNode in 
            // first iteration.
            int nearestVertex = -1;
            int shortestDistance = int.MaxValue;
            for (int vertexIndex = 0;vertexIndex < nVertices; vertexIndex++)
            {
                if (!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                {
                    nearestVertex = vertexIndex;
                    shortestDistance = shortestDistances[vertexIndex];
                }
            }

            // Mark the picked vertex as
            // processed
            added[nearestVertex] = true;

            // Update dist value of the
            // adjacent vertices of the
            // picked vertex.
            for (int vertexIndex = 0;vertexIndex < nVertices;vertexIndex++)
            {
                int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                if (edgeDistance > 0&& ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex]))
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                }
            }
        }
        printSolution(startVertex, shortestDistances, parents);
    }

    // A utility function to print 
    // the constructed distances
    // array and shortest paths
    private static string s;
    private void printSolution(int startVertex,int[] distances, int[] parents)
    {
        s = "";
        int nVertices = distances.Length;
        Debug.Log("Vertex\t Distance\tPath");
        s += "\n" + startVertex + " -> " + nVertices + " \t\t " + distances[nVertices - 1] + "\t\t";
        printPath(nVertices - 1, parents);
        Debug.Log(s);
    }

    // Function to print shortest path
    // from source to currentVertex
    // using parents array
    private void printPath(int currentVertex, int[] parents)
    {
        // Base case : Source node has
        // been processed
        if (currentVertex == NO_PARENT)
        {
            return;
        }

        Renderer[] children;
        children = Instance.nodes[currentVertex].GetComponentsInChildren<Renderer>();

        GameObject obj = Instance.nodes[currentVertex].GetComponentInChildren<Transform>().gameObject;
        shortestPath.Insert(0, obj);
        //Debug.Log(objekt.name);

        foreach (Renderer rend in children)
        {
            rend.material = mat;
        }
        printPath(parents[currentVertex], parents);
        s += currentVertex + " ";
        //Debug.Log(currentVertex + " ");
    }

}