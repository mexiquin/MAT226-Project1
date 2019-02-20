# Nearest Neighbor Heuristic (Written in C#)

## StartPoint.cs

The Startpoint.cs file acts as the main starting point of the program. It initializes all other utility classes.

## GraphInputter.cs

The GraphInputter class handles all of the main math that goes into the heuristic. The GraphInputter class contains methods
such as graphInput(), which guides the user in inputting adjacency matrix values; nearestNeighbor(), which actually conducts the steps of the heuristic
and spits out the optimal route; and checkSurroundingVertexes() which helps the nearestNeighbor() method in identifying the lowest weight edge adjacent to the currently
selected vertex.

## Form1.cs

This is just a class that creates a window showing the user what their entered adjacency matrix looks like, in a more pretty way.

# Running the program

In the upper right, click the green _Clone or download_ button, and download this project as a ZIP file. Then extract the file by right-clicking and selecting _Extract All_

This program is a windows executable (.exe) and can be executed by double-clicking on the **MAT226AlgorithmProject.exe** file located in the
_MAT226AlgorithmProject\bin_ folder

All source (code) files can be found in the _MAT226AlgorithmProject\src_ folder
