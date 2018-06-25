// A C++ program for Dijkstra's single source shortest path algorithm.
// The program is for adjacency matrix representation of the graph
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Number of vertices in the graph


// A utility function to find the vertex with minimum distance value, from
// the set of vertices not yet included in shortest path tree
public class Class1 : MonoBehaviour{
    private int V = 9;
    private static int NO_PARENT = -1;
    //private List <int> nodePath = new List<int>();
    private int[,] graph;

    public Class1(int size, int[,] graph)
    {
        this.V = size;
        this.graph = graph;
        dijkstra(graph, 0);
       // Start();
    }


    public void Start()
    {   /* Let us create the example graph discussed above */
      /*  V = 9;
       int[,] graph = { {0, 4, 0, 0, 0, 0, 0, 8, 0},
                {4, 0, 8, 0, 0, 0, 0, 11, 0},
                {0, 8, 0, 7, 0, 4, 0, 0, 2},
                {0, 0, 7, 0, 9, 14, 0, 0, 0},
                {0, 0, 0, 9, 0, 10, 0, 0, 0},
                {0, 0, 4, 14, 10, 0, 2, 0, 0},
                {0, 0, 0, 0, 0, 2, 0, 1, 6},
                {8, 11, 0, 0, 0, 0, 1, 0, 7},
                {0, 0, 2, 0, 0, 0, 6, 7, 0}};
        dijkstra(graph, 0);*/
    }

    private int minDistance(int[] dist, bool[] sptSet)
    {
        // Initialize min value
        int min = int.MaxValue, min_index = -1;
        for (int v = 0; v < V; v++)
        {
            if (sptSet[v] == false && dist[v] <= min)
            {
                min = dist[v];
                min_index = v;
                Debug.Log("MIN: " + dist[v]);
            }
        }
        return min_index;
    }


    // A utility function to print the constructed distance array
    void printSolution(int[] dist, int n)
    {
        Debug.Log("Vertex   Distance from Source");
        for (int i = 0; i < V; i++)
            Debug.Log(i + "  " + dist[i]);
    }

    private static void dijkstra(int[,] adjacencyMatrix,
                                       int startVertex)
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
        for (int vertexIndex = 0; vertexIndex < nVertices;
                                            vertexIndex++)
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
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (!added[vertexIndex] &&
                    shortestDistances[vertexIndex] <
                    shortestDistance)
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
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                if (edgeDistance > 0
                    && ((shortestDistance + edgeDistance) <
                        shortestDistances[vertexIndex]))
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance +
                                                    edgeDistance;
                }
            }
        }

        printSolution(startVertex, shortestDistances, parents);
    }

    // A utility function to print 
    // the constructed distances
    // array and shortest paths
    private static string s;
    private static void printSolution(int startVertex,int[] distances, int[] parents)
    {
        s = "";
        int nVertices = distances.Length;
        Debug.Log("Vertex\t Distance\tPath");

        for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
        {
            if (vertexIndex != startVertex)
            {
                s += "\n" + startVertex + " -> " +vertexIndex + " \t\t " + distances[vertexIndex] + "\t\t";
                printPath(vertexIndex, parents);
            }
        }
        Debug.Log(s);
    }

    // Function to print shortest path
    // from source to currentVertex
    // using parents array
    private static void printPath(int currentVertex, int[] parents)
    {

        // Base case : Source node has
        // been processed
        if (currentVertex == NO_PARENT)
        {
            return;
        }
        printPath(parents[currentVertex], parents);
        s += currentVertex + " ";
        //Debug.Log(currentVertex + " ");
    }

}