'''
Made by Quinton Jasper

Code designed to simulate the Sorted Edges and
Nearest Neighbor heuristics for identifying
Hamiltonian Circuits
'''
import math


def main():
	# Salutations
	print("Quinton's Hamiltonian Circuit Identifier V1.0\n\n")

	# Obtain graph data
	print(
		"These next steps will guide you in inputting your graph for analysis\n")
	adjacencyMatrix = graphInput()

	# Find nearest neighbor
	print("Result of Nearest Neighbor search:\n",
	      nearestNeighbor(adjacencyMatrix))


# This method uses the bubble sort algorithm to sort
# integers within an array from least to greatest
def bubbleSort(array):
	swappedFlag = None
	indexPass = 0

	while True:
		swappedFlag = False

		while (indexPass < len(array) - 1):
			if array[indexPass] > array[indexPass + 1]:
				swappedFlag = True
				swapValues(array, indexPass, indexPass + 1)

			indexPass += 1

		if (not swappedFlag):
			break


# Swaps two values within a one-dimensional array
def swapValues(array, indexOne, indexTwo):
	# Temporarily holds index to be swapped
	tempSwap = array[indexOne]

	# Overwrites item at index 1
	array[indexOne] = array[indexTwo]

	# Places temp value into index 2
	array[indexTwo] = tempSwap


'''
Controls the input of graph values

Note: this expects that the user has
a pre-established WEIGHTED adjacency matrix that is
ready to be entered into the program. It will
guide them in the entry process
'''


def graphInput():
	# Asks the user to input the number of vertices in their graph
	numOfVertices = input("\nHow many vertices are in your graph?:\n")

	# populate matrix with zeroes
	graphMatrix = []
	for xelement in range(int(numOfVertices)):
		submatrix = []
		for yelement in range(int(numOfVertices)):
			submatrix.append(0)
		graphMatrix.append(submatrix)

	# Begin filling matrix with user-specified values
	for yIndex in range(len(graphMatrix)):
		for xIndex in range(len(graphMatrix[yIndex])):
			if yIndex != xIndex and yIndex > xIndex:
				matrixInput = input("Input weight for path: " +
				                    str(xIndex) + " <--> " + str(
					yIndex) + '\n')
				matrixInput = int(matrixInput)
				graphMatrix[xIndex][yIndex] = matrixInput
				graphMatrix[yIndex][xIndex] = matrixInput

	# Show the user what their entered adjacency matrix looks like
	print("\nHere is the adjacency matrix you entered:\n\n")

	for i in range(len(graphMatrix)):
		for j in range(len(graphMatrix[i])):
			print(graphMatrix[i][j], end="\t")
		print('\n')

	# Send the value of the adjacency matrix back to main
	return graphMatrix


# Nearest Neighbor heuristic for finding hamiltonian circuit
def nearestNeighbor(adjacency_matrix):
	# The starting point for nearest neighbor
	workingIndex = 1
	# Take note of each selected path
	circuitPath = []

	# Take note of each visited vertex
	visitedVertices = []

	# Declare list to hold coordinates for the smallest edge
	smallestEdgeCoords = []

	for iterator in range(len(adjacency_matrix[0])):
		# Choose obsure starting point, 3 in this case

		# Check which surrounding edge is smaller
		smallestEdgeCoords = checkSurroundingVertexes(
			workingIndex, adjacency_matrix, visitedVertices)

		# Add the deduced shortest path to the list
		circuitPath.append(smallestEdgeCoords)

		# set working index as visited
		visitedVertices.append(workingIndex)

		# change working index to the next selected vertex
		workingIndex = smallestEdgeCoords[1]
	return circuitPath


# Starts at the selected vertex, then checks all
# edges that connect to it to see which is smaller
def checkSurroundingVertexes(startingVertex, arrayToAnalyze, visitedvertices):
	smallestEdge = math.inf
	smallestEdgeCoords = []
	iteratorx = 0
	iteratory = startingVertex

	for item in arrayToAnalyze[startingVertex]:
		if item < smallestEdge and \
				iteratorx not in visitedvertices and \
				item > 0:
			smallestEdge = item
			smallestEdgeCoords = [iteratory, iteratorx]

		elif len(visitedvertices) == (len(arrayToAnalyze) - 1) and \
				arrayToAnalyze[iteratory][visitedvertices[0]] > 0:
			smallestEdgeCoords = [iteratory, visitedvertices[0]]
			return smallestEdgeCoords

		elif len(visitedvertices) == (len(arrayToAnalyze) - 1) and \
				arrayToAnalyze[iteratory][visitedvertices[0]] == 0:
			return "Error! No Hamiltonian Circuit exists for this graph"

		iteratorx += 1

	return smallestEdgeCoords


if __name__ == "__main__":
	main()
