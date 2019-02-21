# Nearest Neighbor Algorithm (Written in C# by Quinton Jasper)

## Introduction

The Nearest Neighbor Algorithm is a step-by-step process of identifying the existence of Hamiltonian Circuits within a graph. A Hamiltonian Circuit is a circuit that starts and ends at the same vertex,
and manages to include all vertices in the graph only once. The Nearest Neighbor algorithm identifies a good candidate for a Hamiltonian Circuit by first starting at a specific vertex, and identifying which adjacent
edge is the shortest. Once it finds the shortest edge attached to the current vertex, it will follow that edge and analyze the next shortest edge from the next vertex. It continues this process until we return back
to the vertex we started from.

## Source File Descriptions

### StartPoint.cs

The Startpoint.cs file acts as the main starting point of the program. It initializes all other utility classes.

### GraphInputter.cs

The GraphInputter class handles all of the main math that goes into the Algorithm. The GraphInputter class contains methods
such as graphInput(), which guides the user in inputting adjacency matrix values; nearestNeighbor(), which actually conducts the steps of the Algorithm
and spits out the optimal route; and checkSurroundingVertexes() which helps the nearestNeighbor() method in identifying the lowest weight edge adjacent to the currently
selected vertex.

### Form1.cs

This is just a class that creates a window showing the user what their entered adjacency matrix looks like, in a more organized manner.

## Results

For all graphs I've tested, the program returns a valid answer. My stress-tester graph involved finding the actual distances between the cities of Flagstaff, Phoenix, Los Angeles, San Francisco, Bend, and Carson City and creating an adjacency matrix based on the major highways that connected them all, Flagstaff was the starting point. The result was in that order: Flagstaff --> Phoenix --> Los Angeles --> San Francisco --> Bend --> Carson City --> Flagstaff.

## Future Work

My original goal for this project was to write both algorithms for the Sorted Edges and Nearest Neighbor algorithms and brute-force test them to see which one identified the most efficient circuit. Though, the sorted edge algorithm proved to be more difficult to write than originally expected, taking almost three weeks of consideration before the concept was dropped. Though it may not be integrated now, I would like to eventually incorporate both algorithms and run my tests. I really am interested to see if there is any major benefit to utilizing one algorithm over another.

## Running the program

In the upper right, click the green _Clone or download_ button, and download this project as a ZIP file. Then extract the file by right-clicking and selecting _Extract All_

This program is a windows executable (.exe) and can be executed by double-clicking on the **MAT226AlgorithmProject.exe** file located in the
_MAT226AlgorithmProject\bin_ folder

All source (code) files can be found in the _MAT226AlgorithmProject\src_ folder

**NOTE:** I've also added a backup Python 3 script that has the same functionality in the _MAT226AlgorithmProject\bin_ folder, just in case the .exe file doesn't work
