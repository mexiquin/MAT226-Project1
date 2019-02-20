using System;
using System.Collections.Generic;
using System.Linq;

namespace MAT226AlgorithmProject
{
    /// <summary>
    /// Main class for executing all functionality. Calls GraphInputter for inputting graph weight and vertex values
    /// </summary>
    class StartPoint
    {
        /// <summary>
        /// Entry point for all functionality
        /// </summary>
        public static void Main()
        {
            // Salutations
            Console.WriteLine("Quinton's Hamiltonian Circuit Finder v2.0\n\n");

            // Create new GraphInputter Object
            GraphInputter graphInputter = new GraphInputter();

            // Obtain graph data
            int[,] adjacencyMatrix = graphInput(graphInputter);

            // calculate nearest neighbor circuit
            List<int[]> nNResult = graphInputter.nearestNeighbor(adjacencyMatrix);

            // Print results of Nearest Neighbor
            Console.WriteLine("Result of Nearest Neighbor Search: ");
            pathPrinter(nNResult);

        }

        /// <summary>
        /// Handles the input for graph data; calls GraphInputter class to assist
        /// </summary>
        /// <param name="graphInputter">GraphInputter class that adds graph data input functionality</param>
        /// <returns>Completed adjacency matrix from user input</returns>
        public static int[,] graphInput(GraphInputter graphInputter)
        {
            Console.WriteLine("These next steps will guide you in inputting your graph for analysis");
            int[,] adjacencyMatrix = graphInputter.graphInput();

            return adjacencyMatrix;
        }

        /// <summary>
        /// Formats the array into readable format, vertex pairs contained within []; prints data to command line
        /// </summary>
        /// <param name="pathToPrint">raw List object to convert to readable text</param>
        public static void pathPrinter(List<int[]> pathToPrint)
        {
            for (int iterator = 0; iterator < pathToPrint.Count; iterator++)
            {
                Console.Write("[");
                for (int secondIter = 0; secondIter < pathToPrint.ElementAt(iterator).Length; secondIter++)
                {
                    Console.Write(" {0}", pathToPrint.ElementAt(iterator)[secondIter]);
                }

                Console.Write(" ]");

            }

            // For when all processes are done. Wait for enter-press to end program
            Console.WriteLine("\nPress ENTER to leave...");
            Console.ReadLine();
        }

    }

}
