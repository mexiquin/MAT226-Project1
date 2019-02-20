using System;
using System.Collections.Generic;
using System.Linq;

namespace MAT226AlgorithmProject
{
    /// <summary>
    /// GraphInputter assists in the handling of graph data input and nearest neighbor calculations
    /// </summary>
    class GraphInputter
    {
        /// <summary>
        /// Asks the user for all graph data; based on user's own adjacency matrix
        /// </summary>
        /// <returns>2D array with adjacency values</returns>
        public int[,] graphInput()
        {
            // Asks user to input the number of vertices in their graph
            Console.WriteLine("How many vertices are in your graph?");
            string numOfVertices = Console.ReadLine();
            int vertexCount = Convert.ToInt32(numOfVertices);

            // Populate matrix with zeroes
            int[,] graphMatrix = new int[vertexCount, vertexCount];

            // Begin filling matrix with user-specified values
            for (int yIndex = 0; yIndex < graphMatrix.GetLength(0); yIndex++)
            {
                for (int xIndex = 0; xIndex < graphMatrix.GetLength(1); xIndex++)
                {
                    if (yIndex != xIndex && yIndex > xIndex)
                    {
                        Console.WriteLine("Input weight for path: " + Convert.ToString(xIndex) + " <--> " + Convert.ToString(yIndex) + '\n');
                        string userInput = Console.ReadLine();
                        int matrixInput = Convert.ToInt32(userInput);

                        graphMatrix[xIndex, yIndex] = matrixInput;
                        graphMatrix[yIndex, xIndex] = matrixInput;
                    }
                }
            }

            // Show user what their entered adjacency matrix looks like
            Form1 showMatrix = new Form1(vertexCount, graphMatrix);
            showMatrix.ShowDialog();
            return graphMatrix;
        }

        /// <summary>
        /// Contains the logic for solving nearest neighbor algorithm
        /// </summary>
        /// <param name="adjacency_matrix">the adjacency matrix that the user entered and would like solved</param>
        /// <returns>the optimal circuit as deemed by the algorithm</returns>
        public List<int[]> nearestNeighbor(int[,] adjacency_matrix)
        {
            // The starting point for nearest neighbor
            int workingIndex = 1;

            // take note of selected path
            List<int[]> circuitPath = new List<int[]>();

            // Take note of each visited vertex
            List<int> visitedVertices = new List<int>();

            // Declare list to hold coordinates for the smallest edge
            int[] smallestEdgeCoords;

            for(int iter = 0; iter < adjacency_matrix.GetLength(0); iter++)
            {
                // check which surrounding edge is smaller
                smallestEdgeCoords = checkSurroundingVertexes(workingIndex, adjacency_matrix, visitedVertices);

                // Add the deduced shortest path to the list
                circuitPath.Add(smallestEdgeCoords);

                // Set working index as visited
                visitedVertices.Add(workingIndex);

                // Change working index to the next selected vertex
                workingIndex = smallestEdgeCoords[1];
            }

            return circuitPath;
        }

        /// <summary>
        /// Helps the nearest neighbor algorithm; checks adjacent edges for the smallest size
        /// </summary>
        /// <param name="startingVertex">the starting vertex who's adjacent edges are to be checked</param>
        /// <param name="adjacencyMatrix">the user defined adjacency matrix</param>
        /// <param name="visitedVertices">array holding already-checked vertices</param>
        /// <returns>the shortest edge as deemed by the algorithm</returns>
        private static int[] checkSurroundingVertexes(int startingVertex, int[,] adjacencyMatrix, List<int> visitedVertices)
        {
            // Smallest edge is assigned to INFINITY, but will be changed as edges are analyzed
            double smallestEdge = Double.PositiveInfinity;

            // Holds the coordinates for the seemed smallest edge. 
            int[] smallestEdgeCoords = new int[2];

            // Iterator for column counter
            int iteratorx;

            // Iterator for row counter
            int iteratory = startingVertex;

            // Loop iterates through adjacency matrix, checking the adjacent edges to the specified vertex for shortest length
            for(iteratorx = 0; iteratorx < adjacencyMatrix.GetLength(0); iteratorx++)
            {
                if (adjacencyMatrix[startingVertex, iteratorx] < smallestEdge && !visitedVertices.Contains(iteratorx) && adjacencyMatrix[startingVertex, iteratorx] > 0)
                {
                    smallestEdge = adjacencyMatrix[startingVertex, iteratorx];
                    smallestEdgeCoords[0] = iteratory;
                    smallestEdgeCoords[1] = iteratorx;
                }

                else if (visitedVertices.Count == (adjacencyMatrix.GetLength(0) - 1) && adjacencyMatrix[iteratory, visitedVertices.ElementAt(0)] > 0)
                {
                    smallestEdgeCoords[0] = iteratory;
                    smallestEdgeCoords[1] = visitedVertices.ElementAt(0);

                    return smallestEdgeCoords;
                }

                else if (visitedVertices.Count == adjacencyMatrix.Length - 1 && adjacencyMatrix[iteratory, visitedVertices.ElementAt(0)] == 0)
                {
                    Console.WriteLine("No Hamiltonian Circuit exists for this graph");
                    break;
                }
 
            }

            return smallestEdgeCoords;
        }     
    }
}
